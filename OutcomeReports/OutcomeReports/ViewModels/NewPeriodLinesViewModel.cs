namespace OutcomeReports.ViewModels
{
    using OutcomeReports.Domain.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class NewPeriodLinesViewModel : BaseViewModel
    {
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        int category;
        public int Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public ICommand AddNewPeriodLine { get; set; }

        public INavigation Navigation { get; set; }

        public NewPeriodLinesViewModel()
        {
            AddNewPeriodLine = new Command(async () =>
            {
                var message = string.Empty;
                if (ValidateDates(ref message) == false)
                {
                    ErrorMessage = message;
                }
                else
                {
                    var vm = new LineViewModel();
                    MessagingCenter.Send(this, "AddPeriodLine", vm);
                    await Navigation.PopModalAsync();
                }
            });
        }
        
        private bool ValidateDates(ref string message)
        {
            return true;
        }
    }
}
