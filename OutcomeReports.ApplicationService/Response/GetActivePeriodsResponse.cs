using OutcomeReports.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.ApplicationService
{
    public class GetActivePeriodsResponse : ResponseBase
    {
        public IEnumerable<PeriodViewModel> PeriodViewModels { get; set; }
    }
}
