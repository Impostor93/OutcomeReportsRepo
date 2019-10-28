using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OutcomeReports.ApplicationService;
using OutcomeReports.ApplicationService.Abstraction;
using OutcomeReports.Domain.ViewModels;
using OutcomeReports.Models;
using Xamarin.Forms;

namespace OutcomeReports.ViewModels
{
    public class InitialScreenViewModel : BaseViewModel
    {
        public ICommand CreateNewPeriod { get; set; }

        public ObservableCollection<PeriodViewModel> ActivePeriods { get; set; }

        [Unity.Attributes.Dependency]
        IOutcomeReportService PeriodService { get; set; }

        public InitialScreenViewModel()
        {
            ActivePeriods = new ObservableCollection<PeriodViewModel>();
            LoadData(PeriodService);

            MessagingCenter.Subscribe<Views.NewItemPage, NewPeriod>(this, "AddItem", async (obj, item) =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var response = await PeriodService.CreatePeriodAsync(new CreatePeriodRequest(item.StartDate, item.EndDate));
                if (ReferenceEquals(response.Exception, null) == false)
                {
                    Debug.WriteLine(response.Exception);
                }

                IsBusy = false;
            });
        }

        private void LoadData(IOutcomeReportService periodService)
        {
            Task.Run(async () =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                ActivePeriods.Clear();

                var activePeriods = await periodService.GetActivePeriodsAsync(new GetActivePeriodsRequest());
                if (ReferenceEquals(activePeriods.Exception, null) == false)
                {
                    Debug.WriteLine(activePeriods.Exception);
                }

                foreach (var vm in activePeriods.PeriodViewModels)
                    ActivePeriods.Add(vm);

                IsBusy = false;
            });
        }
    }
}
