using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.ApplicationService
{
    public class CreatePeriodResponse: ResponseBase
    {
        public Guid PeriodId { get; set; }
    }
}
