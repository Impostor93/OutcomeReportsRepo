using OutcomeReports.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Domain.Entities
{
    public class Line: Entity<Guid>
    {
        private Period Period { get; set; }

        public Guid PeriodId { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public string Additional { get; set; }

        public int CategoryId { get; set; }

        private Category Category { get; set; }
    }
}
