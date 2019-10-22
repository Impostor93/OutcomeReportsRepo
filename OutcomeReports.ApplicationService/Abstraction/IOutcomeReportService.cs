using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OutcomeReports.ApplicationService.Abstraction
{
    public interface IOutcomeReportService
    {
        Task<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request);

        Task<GetActivePeriodsResponse> GetActivePeriodsAsync(GetActivePeriodsRequest request);

        Task<AddLineResponse> AddLineAsync(AddLineRequest request);
    }
}
