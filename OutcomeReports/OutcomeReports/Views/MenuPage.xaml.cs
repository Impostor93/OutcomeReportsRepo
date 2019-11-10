using CommonServiceLocator;
using OutcomeReports.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutcomeReports.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        //MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        //List<HomeMenuItem> menuItems;

        public ICommand CategoryPage { get; set; }

        public ICommand PeriodPage { get; set; }

        public ICommand ReportPage { get; set; }

        public MenuPage()
        {
            InitializeComponent();

            CategoryPage = new Command(() =>
            {
                MessagingCenter.Send(this, "NavigateToCategories", this);
            });

            PeriodPage = new Command(() =>
            {
                MessagingCenter.Send(this, "NavigateToPeriod", this);
            });

            ReportPage = new Command(() =>
            {
                MessagingCenter.Send(this, "NavigateToReport", this);
            });

            BindingContext = this;

            //menuItems = new List<HomeMenuItem>
            //{
            //    new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
            //    new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            //};

            //ListViewMenu.ItemsSource = menuItems;

            //ListViewMenu.SelectedItem = menuItems[0];
            //ListViewMenu.ItemSelected += async (sender, e) =>
            //{
            //    if (e.SelectedItem == null)
            //        return;

            //    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            //    await RootPage.NavigateFromMenu(id);
            //};
        }
    }
}