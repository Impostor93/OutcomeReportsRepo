using OutcomeReports.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OutcomeReports.ViewModels
{
    public class NewPeriodViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        DateTime startDate;

        public DateTime StartDate 
        {
            get { return startDate; }
            set { SetProperty(ref startDate, value); }
        }

        DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { SetProperty(ref endDate, value); }
        }

        string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public ICommand AddNewPeriod { get; set; }

        public ICommand Cancel { get; set; }

        public NewPeriodViewModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            AddNewPeriod = new Command(async () => 
            {
                var message = string.Empty;
                if (ValidateDates(ref message) == false)
                {
                    ErrorMessage = message;
                }
                else
                {
                    MessagingCenter.Send(this, "AddPeriod", new NewPeriod(startDate, endDate));
                    await Navigation.PopModalAsync();
                }
            });

            Cancel = new Command(async () =>
            {
                await Navigation.PopModalAsync();
            });
        }

        private bool ValidateDates(ref string message)
        {
            return true;
        }
    }
}
