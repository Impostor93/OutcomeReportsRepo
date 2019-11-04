namespace OutcomeReports.ApplicationService
{
    using System.Collections.Generic;
    using OutcomeReports.Domain.ViewModels;

    public class GetAllCategoriesResponse : ResponseBase
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
