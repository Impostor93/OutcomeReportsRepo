namespace OutcomeReports.Domain.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    public class PeriodReportViewModel
    {
        public PeriodReportViewModel(double totalAmount, IEnumerable<KeyValuePair<CategoryViewModel, double>> outcomesByCategory, IEnumerator<KeyValuePair<DateTime, double>> outcomesByDateTime)
        {
            TotalAmount = totalAmount;
            OutcomesByCategory = outcomesByCategory;
            OutcomesByDate = outcomesByDateTime;

        }

        public double TotalAmount { get; }
        public IEnumerable<KeyValuePair<CategoryViewModel, double>> OutcomesByCategory { get; }

        public IEnumerator<KeyValuePair<DateTime, double>> OutcomesByDate { get; }
    }
}
