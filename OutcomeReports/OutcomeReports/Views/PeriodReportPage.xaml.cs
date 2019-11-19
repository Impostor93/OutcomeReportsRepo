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
           
        }

        protected override void OnAppearing()
        {
            var vm = CommonServiceLocator.ServiceLocator.Current.GetInstance<PeriodReportViewModel>();
            vm.Navigation = this.Navigation;
            BindingContext = vm;
            InitializeComponent();

            ListViewMenu.ItemTapped += (obj, e) => {
                if (e != null && e.Item != null)
                {
                    vm.OnPeriodSelected.Execute(((Domain.ViewModels.PeriodViewModel)e.Item).Id);
                }
            };
            base.OnAppearing();
        }
    }
}