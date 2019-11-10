namespace OutcomeReports.ApplicationService
{
    using System;
    using OutcomeReports.Domain.ViewModels;

    public class GetPeriodReportResponse : ResponseBase
    {
        public PeriodReportViewModel PeriodReport { get; set; }
    }
}
