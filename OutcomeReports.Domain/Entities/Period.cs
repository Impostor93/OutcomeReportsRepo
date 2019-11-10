using OutcomeReports.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutcomeReports.Domain.Entities
{
    public class Period: Entity<Guid>
    {
        private Period()
        {
            Lines = new HashSet<Line>();
        }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int PeriodLength { get; set; }

        public ICollection<Line> Lines { get; set; }

        public IReadOnlyCollection<Line> GetLines()
        {
            return new List<Line>(Lines);
        }

        public void AddLine(double amount, int categoryId, DateTime? date = null)
        {
            AddLine(amount, categoryId, date);
        }

        public void AddLine(double amount, int categoryId, string additionalData, DateTime? date = null)
        {
            if (date.HasValue)
            {
                if (date < Start || date > End)
                    throw new Exception("The line date does not fall within period range!");
            }
            else
            {
                date = DateTime.Now;
            }

            var newLine = new Line()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                CategoryId = categoryId,
                Date = date.Value,
                Additional = additionalData,
                PeriodId = Id
            };

            Lines.Add(newLine);
        }

        public static Period StartPeriod(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new Exception("Invalid period range!");

            var periodLength = (int)(endDate - startDate).TotalDays;

            return new Period() { Id = Guid.NewGuid(), Start = startDate, End = endDate, PeriodLength = periodLength };
        }

        public static Period StartPeriod(DateTime startDate, int dayCounts)
        {
            return StartPeriod(startDate, startDate.AddDays(dayCounts));
        }

        public IEnumerable<KeyValuePair<int, double>> GetReportByCategories()
        {
            var groups = Lines.GroupBy(e => e.CategoryId);
            var outcomesByCategory = new List<KeyValuePair<int, double>>();
            foreach (var group in groups)
            {
                var categoryId = group.Key;
                var totalAmountPerCategory = group.Sum(e => e.Amount);

                outcomesByCategory.Add(new KeyValuePair<int, double>(categoryId, totalAmountPerCategory));
            }

            return outcomesByCategory;
        }

        public IEnumerator<KeyValuePair<DateTime, double>> GetReportByDate()
        {
            var outcomesByDateTime = new List<KeyValuePair<DateTime, double>>();
            var groupsByDate = Lines.GroupBy(e => e.Date);
            var outcomesByDate = new List<KeyValuePair<DateTime, double>>();
            foreach (var group in groupsByDate)
            {
                var date = group.Key;
                var totalAmountPerDate = group.Sum(e => e.Amount);

                outcomesByDateTime.Add(new KeyValuePair<DateTime, double>(date, totalAmountPerDate));
            }

            return (IEnumerator<KeyValuePair<DateTime, double>>)outcomesByDateTime;
        }

        public double TotalAmount()
        {
            return Lines.Sum(e => e.Amount);
        }
    }
}
