﻿using OutcomeReports.ApplicationService;
using OutcomeReports.ApplicationService.Abstraction;
using OutcomeReports.Domain.ViewModels;
using OutcomeReports.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OutcomeReports.ViewModels
{
    public class PeriodLinesViewModel : BaseViewModel
    {
        public PeriodViewModel PeriodViewModel { get; set; }

        private readonly IOutcomeReportServiceProvider provider;

        public ICommand AddLine;

        internal INavigation Navigation;

        public PeriodLinesViewModel(IOutcomeReportServiceProvider provider)
        {
            this.provider = provider;
            AddLine = new Command(async () =>
            {
                await Navigation.PushModalAsync(new NewPeriodLinePage());
            });
        }
    }
}
