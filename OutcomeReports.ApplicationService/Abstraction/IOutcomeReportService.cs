using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OutcomeReports.ApplicationService.Abstraction
{
    public interface IOutcomeReportService : IDisposable
    {
        Task<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request);

        Task<GetActivePeriodsResponse> GetActivePeriodsAsync(GetActivePeriodsRequest request);

        Task<GetPeriodResponse> GetPeriodAsync(GetPeriodByIdRequest request);

        Task<AddLineResponse> AddLineAsync(AddLineRequest request);

        Task<GetPeriodReportResponse> GetPeriodReportAsync(GetPeriodReportRequest request);

        Task<GetAllPeriodsResponse> GetAllPeriodsAsync(GetAllPeriodsRequest request);
    }
}
