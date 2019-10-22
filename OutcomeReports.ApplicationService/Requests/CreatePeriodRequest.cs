using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.ApplicationService
{
    public class CreatePeriodRequest: RequestBase
    {
        public CreatePeriodRequest(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }
        public DateTime End { get; }
    }
}
