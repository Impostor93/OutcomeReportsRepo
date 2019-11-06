namespace OutcomeReports.ApplicationService
{
    using OutcomeReports.Domain.ViewModels;

    public class GetPeriodResponse : ResponseBase
    {
        public PeriodViewModel Period { get; set; }
    }
}
