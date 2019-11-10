namespace OutcomeReports.ApplicationService.Implementation
{
    using AutoMapper;
    using OutcomeReports.ApplicationService.Abstraction;
    using OutcomeReports.Domain;
    using OutcomeReports.Domain.Entities;
    using OutcomeReports.Domain.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OutcomeReportService : IOutcomeReportService
    {
        private readonly IOutcomeReportUnitOfWork unitOfWork;
        private readonly MapperConfiguration mapperConfig;

        public OutcomeReportService(IOutcomeReportUnitOfWork unitOfWork, MapperConfiguration mapperConfig)
        {
            this.unitOfWork = unitOfWork;
            this.mapperConfig = mapperConfig;
        }

        public async Task<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new CreatePeriodResponse();

                try
                {
                    var newPeriod = Period.StartPeriod(request.Start, request.End);
                    unitOfWork.PeriodRepository.Create(newPeriod);

                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                }

                return response;
            });
        }

        public async Task<GetActivePeriodsResponse> GetActivePeriodsAsync(GetActivePeriodsRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new GetActivePeriodsResponse();

                try
                {
                    var activePeriods = unitOfWork.PeriodRepository.GetActivePeriods();
                    var mapper = mapperConfig.CreateMapper();

                    response.PeriodViewModels = mapper.Map<IEnumerable<Period>, IEnumerable<PeriodViewModel>>(activePeriods);
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                }

                return response;
            });
        }

        public async Task<AddLineResponse> AddLineAsync(AddLineRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new AddLineResponse();

                try
                {
                    var period = unitOfWork.PeriodRepository.GetPeriod(request.PeriodId);

                    period.AddLine(request.Amount, request.Category, request.Additional, request.Date);

                    unitOfWork.PeriodRepository.Update(period);

                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                }

                return response;
            });
        }

        public async Task<GetPeriodResponse> GetPeriodAsync(GetPeriodByIdRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new GetPeriodResponse();

                if (request.Id == Guid.Empty)
                    throw new ArgumentException(nameof(request.Id));

                try
                {
                    var period = unitOfWork.PeriodRepository.GetPeriod(request.Id);
                    if (ReferenceEquals(period, null))
                        throw new Exception("Period is not found!");

                    var mapper = mapperConfig.CreateMapper();

                    response.Period = mapper.Map<Period, PeriodViewModel>(period);
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                }

                return response;
            });
        }

        public async Task<GetPeriodReportResponse> GetPeriodReportAsync(GetPeriodReportRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new GetPeriodReportResponse();

                try
                {
                    var period = unitOfWork.PeriodRepository.GetPeriod(request.PeriodId);
                    var categories = unitOfWork.CategoryRepository.GetAllCategories();

                    if (ReferenceEquals(period, null))
                        throw new Exception("Period is not found!");

                    var mapper = mapperConfig.CreateMapper();
                    var outcomesByDateTime = period.GetReportByDate();

                    var outcomesByCategory = new List<KeyValuePair<CategoryViewModel, double>>();
                    foreach (var reportForCategory in period.GetReportByCategories())
                    {
                        var category = categories.First(e => e.Id == reportForCategory.Key);
                        var categoryVM = mapper.Map<Category, CategoryViewModel>(category);
                        outcomesByCategory.Add(new KeyValuePair<CategoryViewModel, double>(categoryVM, reportForCategory.Value));
                    }

                    var periodReport = new PeriodReportViewModel(period.TotalAmount(), outcomesByCategory, outcomesByDateTime);

                    response.PeriodReport = periodReport;
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                }

                return response;
            });
        }

        public async Task<GetAllPeriodsResponse> GetAllPeriodsAsync(GetAllPeriodsRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new GetAllPeriodsResponse();

                try
                {
                    var periods = unitOfWork.PeriodRepository.GetPeriods();
                    var mapper = mapperConfig.CreateMapper();

                    var periodViewModels = mapper.Map<IEnumerable<Period>, IEnumerable<PeriodViewModel>>(periods);

                    response.PeriodViewModels = periodViewModels;
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
