namespace OutcomeReports.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using OutcomeReports.ApplicationService.Abstraction;
    using OutcomeReports.Domain.ViewModels;
    using Xamarin.Forms;

    public class PeriodReportViewModel : BaseViewModel
    {
        public ObservableCollection<PeriodViewModel> Periods { get; set; }

        public ICommand OnPeriodSelected { get; set; }

        public PeriodReportViewModel(IOutcomeReportServiceProvider provider)
        {
            Periods = new ObservableCollection<PeriodViewModel>();

            Task.Run(async () => await LoadDate(provider));

            OnPeriodSelected = new Command(() =>
            {

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
