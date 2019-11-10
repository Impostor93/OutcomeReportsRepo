namespace OutcomeReports.ApplicationService
{
    using System;

    public class GetPeriodReportRequest : RequestBase
    {
        public GetPeriodReportRequest(Guid periodId)
        {
            PeriodId = periodId;
        }

        public Guid PeriodId { get; }
    }
}
