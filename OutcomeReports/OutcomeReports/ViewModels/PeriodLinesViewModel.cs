using OutcomeReports.ApplicationService;
using OutcomeReports.ApplicationService.Abstraction;
using OutcomeReports.Domain.ViewModels;
using OutcomeReports.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OutcomeReports.ViewModels
{
    public class PeriodLinesViewModel : BaseViewModel
    {
        public Guid PeriodViewModelId { get; set; }

        public ObservableCollection<LineViewModel> Lines { get; set; }

        public ICommand AddLine { get; set; }

        public ICommand ScanQr { get; set; }

        internal INavigation Navigation { get; set; }

        public PeriodLinesViewModel(IOutcomeReportServiceProvider provider)
        {
            Lines = new ObservableCollection<LineViewModel>();

            Task.Run(async () => await LoadData(provider));

            AddLine = new Command(async () =>
            {
                MessagingCenter.Subscribe<NewPeriodLinesViewModel, NewPeriodLinesViewModel>(this, "AddPeriodLine", async (obj, item) =>
                {
                    await AddPeriodLine(provider, item);
                });

                var page = new NewPeriodLinePage();
                page.Disappearing += (obj, arg) =>
                {
                    MessagingCenter.Instance.Unsubscribe<NewPeriodLinesViewModel, NewPeriodLinesViewModel>(this, "AddPeriodLine");
                };
                await Navigation.PushModalAsync(page);
            });

            ScanQr = new Command(async () =>
            {
                try
                {
                    var scanner = DependencyService.Get<OutcomeReport.QRService.IQrScanningService>();
                    var result = await scanner.ScanAsync();
                    if (result != null)
                    {

                        var splitedContent = result.Split('*');
                        var date = DateTime.Parse($"{splitedContent[2]} {splitedContent[3]}");
                        var amount = double.Parse(splitedContent[4]);

                        MessagingCenter.Subscribe<NewPeriodLinesViewModel, NewPeriodLinesViewModel>(this, "AddPeriodLine", async (obj, item) =>
                        {
                            await AddPeriodLine(provider, item);
                        });

                        var page = new NewPeriodLinePage();
                        page.Disappearing += (obj, arg) =>
                        {
                            MessagingCenter.Instance.Unsubscribe<NewPeriodLinesViewModel, NewPeriodLinesViewModel>(this, "AddPeriodLine");
                        };
                        ((NewPeriodLinesViewModel)page.BindingContext).Amount = amount;
                        ((NewPeriodLinesViewModel)page.BindingContext).Date = date;
                        await Navigation.PushModalAsync(page);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        private async Task AddPeriodLine(IOutcomeReportServiceProvider provider, NewPeriodLinesViewModel item)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            using (var periodService = provider.GetService())
            {
                DateTime? date = item.Date;
                if (ReferenceEquals(date, null) || date == DateTime.MinValue || date == DateTime.MaxValue)
                {
                    date = null;
                }

                var request = new AddLineRequest(PeriodViewModelId, item.Amount, item.Category.Id, item.Description, date);

                var response = await periodService.AddLineAsync(request);
                if (ReferenceEquals(response.Exception, null) == false)
                {
                    Debug.WriteLine(response.Exception);
                }
            }

            IsBusy = false;

            await LoadData(provider);
        }

        private async Task LoadData(IOutcomeReportServiceProvider provider)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            using (var periodService = provider.GetService())
            {
                var response = await periodService.GetPeriodAsync(new GetPeriodByIdRequest(PeriodViewModelId));
                if (ReferenceEquals(response.Exception, null) == false)
                {
                    Debug.WriteLine(response.Exception);
                }
                else
                {
                    Lines.Clear();
                    foreach (var line in response.Period.Lines)
                        Lines.Add(line);
                }
            }

            IsBusy = false;
        }
    }
}
