using OutcomeReports.Data.Repositories;
using OutcomeReports.Domain;
using OutcomeReports.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Data
{
    public class OutcomeReportUnitOfWork : IOutcomeReportUnitOfWork
    {
        private OutcomeReportsContext context;

        public OutcomeReportUnitOfWork(string dbPath)
        {
            this.context = new OutcomeReportsContext(dbPath);
        }

        IPeriodRepository periodRepository;

        public IPeriodRepository PeriodRepository
        {
            get 
            {
                if (ReferenceEquals(periodRepository, null))
                {
                    periodRepository = new PeriodRepository(context);
                }

                return periodRepository;
            }
        }

        ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (ReferenceEquals(categoryRepository, null))
                {
                    categoryRepository = new CategoryRepository(context);
                }

                return categoryRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
