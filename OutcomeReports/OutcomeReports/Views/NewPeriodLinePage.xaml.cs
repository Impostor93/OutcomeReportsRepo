using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OutcomeReports.Models;
using OutcomeReports.Views;
using OutcomeReports.ViewModels;

namespace OutcomeReports.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewPeriodLinePage : ContentPage
    {
        public NewPeriodLinePage()
        {
            InitializeComponent();
            var vm = CommonServiceLocator.ServiceLocator.Current.GetInstance<NewPeriodLinesViewModel>();
            vm.Navigation = Navigation;

            BindingContext = vm;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}