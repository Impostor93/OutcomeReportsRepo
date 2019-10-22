using OutcomeReports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Domain.Repositories
{
    public interface IPeriodRepository
    {
        Period GetPeriod(Guid periodId);

        IEnumerable<Period> GetPeriods();

        IEnumerable<Period> GetPeriods(DateTime date);

        IEnumerable<Period> GetPeriods(DateTime date, DateTime endDate);

        IEnumerable<Period> GetActivePeriods();

        Guid Create(Period period);

        void Update(Period period);
    }
}
