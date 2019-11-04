using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OutcomeReports.Models;
using OutcomeReports.ViewModels;
using CommonServiceLocator;
using OutcomeReports.Domain.ViewModels;

namespace OutcomeReports.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PeriodLinesPage : ContentPage
    {
        public PeriodLinesPage(PeriodViewModel viewModel)
        {
            InitializeComponent();
            var vm = ServiceLocator.Current.GetInstance<PeriodLinesViewModel>();
            vm.PeriodViewModel = viewModel;
            vm.Navigation = this.Navigation;

            BindingContext = vm;
        }
    }
}