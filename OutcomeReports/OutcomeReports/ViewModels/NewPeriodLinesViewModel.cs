namespace OutcomeReports.ViewModels
{
    using OutcomeReports.ApplicationService;
    using OutcomeReports.ApplicationService.Abstraction;
    using OutcomeReports.Domain.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
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

        CategoryViewModel category;
        public CategoryViewModel Category
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

        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public ICommand AddNewPeriodLine { get; set; }

        public ICommand Cancel { get; set; }

        public INavigation Navigation { get; set; }

        public NewPeriodLinesViewModel(IOutcomeReportCategoryServiceProvider categoryServiceProvider)
        {
            Title = "Period New Line";
            Date = DateTime.Now;

            Categories = new ObservableCollection<CategoryViewModel>();
            Task.Run(async () => await LoadCategories(categoryServiceProvider));

            AddNewPeriodLine = new Command(async () =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var message = string.Empty;
                if (ValidateDates(ref message) == false)
                {
                    ErrorMessage = message;
                }
                else
                {
                    MessagingCenter.Send(this, "AddPeriodLine", this);
                    await Navigation.PopModalAsync();
                }

                IsBusy = false;
            });

            Cancel = new Command(async () =>
            {
                await Navigation.PopModalAsync();
            });
        }

        private async Task LoadCategories(IOutcomeReportCategoryServiceProvider categoryServiceProvider)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            using (var categoryService = categoryServiceProvider.GetService())
            {
                var response = await categoryService.GetAllAsync(new GetAllCategoriesRequest());
                if (ReferenceEquals(response.Exception, null))
                {
                    foreach(var ct in response.Categories)
                        Categories.Add(ct);
                }
                else
                {
                    Debug.WriteLine(response.Exception.Message);
                }
            }

            IsBusy = false;
        }

        private bool ValidateDates(ref string message)
        {
            return true;
        }
    }
}
