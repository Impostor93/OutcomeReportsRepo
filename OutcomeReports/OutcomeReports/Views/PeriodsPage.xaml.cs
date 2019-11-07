using CommonServiceLocator;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutcomeReports.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeriodsPage : ContentPage
    {
        public PeriodsPage()
        {
            InitializeComponent();
            
            var vm = ServiceLocator.Current.GetInstance<ViewModels.PeriodsViewModel>();
            vm.Navigation = this.Navigation;

            BindingContext = vm;

            ListViewMenu.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                if (e != null && e.Item != null)
                {
                    vm.OpenPeriod.Execute((Domain.ViewModels.PeriodViewModel)e.Item);
                }
            };
        }
    }
}
