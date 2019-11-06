namespace OutcomeReports.ApplicationService.Abstraction
{
    using System;
    using System.Threading.Tasks;

    public interface IOutcomeReportCategoryService: IDisposable
    {
        Task<GetAllCategoriesResponse> GetAllAsync(GetAllCategoriesRequest request);

        Task<CreateCategoriesResponse> CreateCategoryAsync(CreateCategoriesRequest request);
    }
}
