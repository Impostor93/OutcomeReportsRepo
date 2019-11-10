using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OutcomeReports.Models;

namespace OutcomeReports.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        NavigationPage Category;

        NavigationPage Periods;

        NavigationPage Report;

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            Category = new NavigationPage(new CategoriesPage());
            Report = new NavigationPage(new PeriodReportPage());
            Periods = (NavigationPage)Detail;

            MessagingCenter.Subscribe<MenuPage, MenuPage>(this, "NavigateToCategories", (a, b) =>
            {
                Detail = Category;
            });

            MessagingCenter.Subscribe<MenuPage, MenuPage>(this, "NavigateToPeriod", (a, b) =>
            {
                Detail = Periods;
            });

            MessagingCenter.Subscribe<MenuPage, MenuPage>(this, "NavigateToReport", (a, b) =>
            {
                Detail = Report;
            });
        }
    }
}