﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OutcomeReports.ApplicationService;
using OutcomeReports.ApplicationService.Abstraction;
using OutcomeReports.Domain.ViewModels;
using OutcomeReports.Models;
using OutcomeReports.Views;
using Xamarin.Forms;

namespace OutcomeReports.ViewModels
{
    public class PeriodsViewModel : BaseViewModel
    {
        public ICommand CreateNewPeriod { get; set; }

        public ICommand OpenPeriod { get; set; }

        public ICommand Disappearing { get; set; }

        public ObservableCollection<PeriodViewModel> ActivePeriods { get; set; }

        public INavigation Navigation { get; set; }

        public PeriodsViewModel(IOutcomeReportServiceProvider outcomeReportServiceProvider, IOutcomeReportCategoryServiceProvider w)
        {
            ActivePeriods = new ObservableCollection<PeriodViewModel>();
            LoadData(outcomeReportServiceProvider);

            CreateNewPeriod = new Command(async () =>
            {
                MessagingCenter.Subscribe<NewPeriodViewModel, NewPeriod>(this, "AddPeriod", async (obj, item) =>
                {
                    await AddPeriod(outcomeReportServiceProvider, item);
                });

                var page = new NewPeriodPage();
                page.Disappearing += (obj, arg) => { MessagingCenter.Unsubscribe<NewPeriodViewModel, NewPeriod>(this, "AddPeriod"); };
                await Navigation.PushModalAsync(page);
            });

            OpenPeriod = new Command(async (item) =>
            {
                await Navigation.PushAsync(new PeriodLinesPage((PeriodViewModel)item));
            });
        }

        private async Task AddPeriod(IOutcomeReportServiceProvider outcomeReportServiceProvider, NewPeriod item)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            using (var periodService = outcomeReportServiceProvider.GetService())
            {
                var response = await periodService.CreatePeriodAsync(new CreatePeriodRequest(item.StartDate, item.EndDate));
                if (ReferenceEquals(response.Exception, null) == false)
                {
                    Debug.WriteLine(response.Exception);
                }
            }

            IsBusy = false;

            LoadData(outcomeReportServiceProvider);
        }

        private void LoadData(IOutcomeReportServiceProvider outcomeReportServiceProvider)
        {
            Task.Run(async () =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                ActivePeriods.Clear();
                try
                {
                    using (var periodService = outcomeReportServiceProvider.GetService())
                    {
                        var activePeriods = await periodService.GetActivePeriodsAsync(new GetActivePeriodsRequest());
                        if (ReferenceEquals(activePeriods.Exception, null) == false)
                        {
                            Debug.WriteLine(activePeriods.Exception);
                        }

                        foreach (var vm in activePeriods.PeriodViewModels)
                            ActivePeriods.Add(vm);
                    }
                }
                catch (System.Exception ex)
                {
                    var e = ex;
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
    }
}
