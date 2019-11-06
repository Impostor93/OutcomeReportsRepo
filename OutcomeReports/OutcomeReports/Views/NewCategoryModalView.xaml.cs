using OutcomeReports.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutcomeReports.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCategoryModalView : ContentPage
    {
        public NewCategoryModalView()
        {
            InitializeComponent();

            var vm = CommonServiceLocator.ServiceLocator.Current.GetInstance<NewCategoryViewModel>();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}