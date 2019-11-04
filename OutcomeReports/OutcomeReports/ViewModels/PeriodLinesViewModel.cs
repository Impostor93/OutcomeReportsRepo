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
        public PeriodViewModel PeriodViewModel { get; set; }

        public ObservableCollection<LineViewModel> Lines { get; set; }

        public ICommand AddLine;

        internal INavigation Navigation;

        public PeriodLinesViewModel(IOutcomeReportServiceProvider provider)
        {
            Lines = new ObservableCollection<LineViewModel>(PeriodViewModel.Lines);

            AddLine = new Command(async () =>
            {
                await Navigation.PushModalAsync(new NewPeriodLinePage());
            });

            MessagingCenter.Subscribe<NewPeriodLinesViewModel, NewPeriodLinesViewModel>(this, "AddPeriodLine", async (obj, item) =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                using (var periodService = provider.GetService())
                {
                    //TODO: Implement add line method logic 

                    //var response = await periodService.CreatePeriodAsync(new CreatePeriodRequest(item.StartDate, item.EndDate));
                    //if (ReferenceEquals(response.Exception, null) == false)
                    //{
                    //    Debug.WriteLine(response.Exception);
                    //}
                }

                IsBusy = false;

                await LoadData(provider);
            });
        }

        private async Task LoadData(IOutcomeReportServiceProvider provider)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            using (var periodService = provider.GetService())
            {
                //TODO: Implement get by id

                //var response = await periodService.GetPeriodByIdAsync();
                //if (ReferenceEquals(response.Exception, null) == false)
                //{
                //    Debug.WriteLine(response.Exception);
                //}
            }

            IsBusy = false;
        }
    }
}
