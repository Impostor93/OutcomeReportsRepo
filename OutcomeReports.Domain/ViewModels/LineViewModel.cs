using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Domain.ViewModels
{
    public class LineViewModel
    {
        public Guid Id { get; set; }

        public Guid PeriodId { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public string Additional { get; set; }

        public int CategoryId { get; set; }
    }
}
