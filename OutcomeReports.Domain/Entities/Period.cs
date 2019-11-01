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
                //TODO: validate if date fall in the Period frames
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
            //TODO validate start and end dates

            var periodLength = (int)(endDate - startDate).TotalDays;

            return new Period() { Id = Guid.NewGuid(), Start = startDate, End = endDate, PeriodLength = periodLength };
        }

        public static Period StartPeriod(DateTime startDate, int dayCounts)
        {
            return StartPeriod(startDate, startDate.AddDays(dayCounts));
        }
    }
}
