namespace OutcomeReports.ApplicationService.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using OutcomeReports.ApplicationService.Abstraction;
    using OutcomeReports.Domain;
    using OutcomeReports.Domain.Entities;
    using OutcomeReports.Domain.ViewModels;

    public class OutcomeReportCategoryService : IOutcomeReportCategoryService
    {
        private readonly IOutcomeReportUnitOfWork unitOfWork;
        private readonly MapperConfiguration mapperConfig;

        public OutcomeReportCategoryService(IOutcomeReportUnitOfWork unitOfWork, MapperConfiguration mapperConfig)
        {
            this.unitOfWork = unitOfWork;
            this.mapperConfig = mapperConfig;
        }

        public async Task<GetAllCategoriesResponse> GetAllAsync(GetAllCategoriesRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new GetAllCategoriesResponse();

                try
                {
                    var allCategories = unitOfWork.CategoryRepository.GetAllCategories();
                    var mapper = mapperConfig.CreateMapper();

                    response.Categories = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(allCategories);
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                }

                return response;
            });
        }

        public void Dispose()
        {
            if (ReferenceEquals(unitOfWork, null) == false)
                unitOfWork.Dispose();
        }
    }
}
