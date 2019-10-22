using OutcomeReports.Domain.Repositories;
using OutcomeReports.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Domain
{
    public interface IOutcomeReportUnitOfWork : IUnitOfWork
    {
        IPeriodRepository PeriodRepository { get; }

        ICategoryRepository CategoryRepository { get; }
    }
}
