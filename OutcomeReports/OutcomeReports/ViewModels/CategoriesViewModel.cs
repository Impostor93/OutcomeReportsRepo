namespace OutcomeReports.ViewModels
{
    using OutcomeReports.ApplicationService;
    using OutcomeReports.ApplicationService.Abstraction;
    using OutcomeReports.Domain.ViewModels;
    using OutcomeReports.Views;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public ICommand AddCategory { get; set; }

        public INavigation Navigation { get; set; }

        public CategoriesViewModel(IOutcomeReportCategoryServiceProvider provider)
        {
            Categories = new ObservableCollection<CategoryViewModel>();
            Task.Run(async () => await LoadDate(provider));

            AddCategory = new Command(async () =>
            {
                await Navigation.PushModalAsync(new NewCategoryModalView());
            });

            MessagingCenter.Subscribe<NewCategoryViewModel, string>(this, "AddCategory", async (obj, item) =>
            {
                using (var service = provider.GetService())
                {
                    var categoriesResponse = await service.CreateCategoryAsync(new CreateCategoriesRequest(item));
                    if (ReferenceEquals(categoriesResponse.Exception, null) == false)
                    {
                        Debug.WriteLine(categoriesResponse.Exception);
                    }
                }

                await LoadDate(provider);
            });
        }

        private async Task LoadDate(IOutcomeReportCategoryServiceProvider provider)
        {
            using (var service = provider.GetService())
            {
                var categoriesResponse = await service.GetAllAsync(new ApplicationService.GetAllCategoriesRequest());
                if (ReferenceEquals(categoriesResponse.Exception, null))
                {
                    Categories.Clear();

                    foreach (var cat in categoriesResponse.Categories)
                        Categories.Add(cat);
                }
                else
                {
                    Debug.WriteLine(categoriesResponse.Exception);
                }
            }
        }
    }
}
