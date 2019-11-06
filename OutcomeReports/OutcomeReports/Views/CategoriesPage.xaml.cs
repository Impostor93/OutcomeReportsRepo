namespace OutcomeReports.Views
{
    using OutcomeReports.ViewModels;
    using System.ComponentModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            var vm = CommonServiceLocator.ServiceLocator.Current.GetInstance<CategoriesViewModel>();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
