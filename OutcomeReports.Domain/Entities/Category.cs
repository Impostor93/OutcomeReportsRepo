using OutcomeReports.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Domain.Entities
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
    }
}
