﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OutcomeReports.Services;
using OutcomeReports.Views;
using OutcomeReports.Domain.Repositories;
using OutcomeReports.Data.Repositories;
using OutcomeReports.Facility;
using Unity;
using OutcomeReports.SharedKernel.Extensions;
using Unity.ServiceLocation;
using CommonServiceLocator;
using OutcomeReports.ViewModels;

namespace OutcomeReports
{
    public partial class App : Application
    {
        private readonly UnityContainer container;

        public App(string sqliteConnectionString)
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();

            this.container = new UnityContainer();
            this.container.AddFacility(new OutcomeReportsFacility(sqliteConnectionString));
            RegisterViewModels(container);

            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            MainPage = new MainPage();
        }

        private void RegisterViewModels(UnityContainer container)
        {
            //container.RegisterType<PeriodsViewModel>();
            //container.RegisterType<NewPeriodViewModel>();
            //container.RegisterType<PeriodLinesViewModel>();

            container.RegisterInstance(typeof(PeriodsViewModel));
            container.RegisterInstance(typeof(NewPeriodViewModel));
            container.RegisterInstance(typeof(PeriodLinesViewModel));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
