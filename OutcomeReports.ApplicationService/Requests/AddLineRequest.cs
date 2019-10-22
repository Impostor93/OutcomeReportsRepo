using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.ApplicationService
{
    public class AddLineRequest : RequestBase
    {
        public AddLineRequest(Guid periodId, double amount, int category, string additional = "", DateTime? date = null)
        {
            PeriodId = periodId;
            Amount = amount;
            Category = category;
            Additional = additional;
            Date = date;
        }

        public Guid PeriodId { get; }

        public double Amount { get; }
        public int Category { get; }
        public string Additional { get; }
        public DateTime? Date { get; }
    }
}
