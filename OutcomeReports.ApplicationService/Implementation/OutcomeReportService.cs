using AutoMapper;
using OutcomeReports.ApplicationService.Abstraction;
using OutcomeReports.Domain;
using OutcomeReports.Domain.Entities;
using OutcomeReports.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutcomeReports.ApplicationService.Implementation
{
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

        public void Dispose()
        {
            if (ReferenceEquals(unitOfWork, null) == false)
                unitOfWork.Dispose();
        }
    }
}
