using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Models
{
    public class NewPeriod
    {
        public NewPeriod(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
