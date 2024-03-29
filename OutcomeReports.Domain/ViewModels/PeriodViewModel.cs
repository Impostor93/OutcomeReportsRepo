﻿using System;
using System.Collections.Generic;

namespace OutcomeReports.Domain.ViewModels
{
    public class PeriodViewModel
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int PeriodLength { get; set; }

        public IEnumerable<LineViewModel> Lines { get; set; }

        public string PeriodTitle { get { return $"{Start.Date.ToString("dd/MM/yyyy")} - {End.Date.ToString("dd/MM/yyyy")}"; } }
    }
}
