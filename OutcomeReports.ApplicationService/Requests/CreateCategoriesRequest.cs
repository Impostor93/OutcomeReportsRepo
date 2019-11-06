namespace OutcomeReports.ApplicationService
{
    using OutcomeReports.Domain.ViewModels;

    public class CreateCategoriesRequest : RequestBase
    {
        public string NewCategoryName;

        public CreateCategoriesRequest(string newCategoryName)
        {
            NewCategoryName = newCategoryName;
        }
    }
}
