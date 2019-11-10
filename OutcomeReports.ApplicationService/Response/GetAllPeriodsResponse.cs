namespace OutcomeReports.ApplicationService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OutcomeReports.Domain.ViewModels;

    public class GetAllPeriodsResponse : ResponseBase
    {
        public IEnumerable<PeriodViewModel> PeriodViewModels { get; internal set; }
    }
}
