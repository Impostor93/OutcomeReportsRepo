namespace OutcomeReports.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using OutcomeReports.ApplicationService;
    using OutcomeReports.ApplicationService.Abstraction;
    using OutcomeReports.Domain.ViewModels;
    using OutcomeReports.Views;
    using Xamarin.Forms;

    public class PeriodReportViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ObservableCollection<PeriodViewModel> Periods { get; set; }

        public ICommand OnPeriodSelected { get; set; }

        public PeriodReportViewModel(IOutcomeReportServiceProvider provider)
        {
            Periods = new ObservableCollection<PeriodViewModel>();

            Task.Run(async () => await LoadDate(provider));

            OnPeriodSelected = new Command(async (periodId) =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                using (var service = provider.GetService())
                {
                    var reportPage = new PeriodOutcomeReport();
                    var report = await service.GetPeriodReportAsync(new GetPeriodReportRequest((Guid)periodId));
                    if (ReferenceEquals(report.Exception, null))
                    {
                        reportPage.BindingContext = report.PeriodReport;
                        await Navigation.PushModalAsync(new NavigationPage(reportPage));
                    }
                    else
                    {
                        Debug.WriteLine(report.Exception);
                    }
                }

                IsBusy = false;
            });
        }

        private async Task LoadDate(IOutcomeReportServiceProvider provider)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            using (var service = provider.GetService())
            {
                var response = await service.GetAllPeriodsAsync(new ApplicationService.GetAllPeriodsRequest());
                if (ReferenceEquals(response.Exception, null))
                {
                    foreach (var vm in response.PeriodViewModels)
                        Periods.Add(vm);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(response.Exception);
                }
            }

            IsBusy = false;
        }
    }
}
