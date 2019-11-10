using OutcomeReports.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutcomeReports.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeriodReportPage : ContentPage
    {
        public PeriodReportPage()
        {
            var vm = CommonServiceLocator.ServiceLocator.Current.GetInstance<PeriodReportViewModel>();
            BindingContext = vm;
            InitializeComponent();

            ListViewMenu.ItemTapped += (obj, e) => {
                if (e != null && e.Item != null)
                {
                    vm.OnPeriodSelected.Execute((Domain.ViewModels.PeriodViewModel)e.Item);
                }
           };
        }
    }
}