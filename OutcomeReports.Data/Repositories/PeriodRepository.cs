using OutcomeReports.Domain.Entities;
using OutcomeReports.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OutcomeReports.Data.Repositories
{
    public class PeriodRepository : IPeriodRepository
    {
        private OutcomeReportsContext context;
        private RepositoryBase<Period> baseRepo;

        public PeriodRepository(OutcomeReportsContext context)
        {
            this.context = context;
            this.baseRepo = new RepositoryBase<Period>(context);
        }

        public Guid Create(Period period)
        {
            baseRepo.Create(period);

            return period.Id;
        }

        public void Update(Period period)
        {
            baseRepo.Update(period);
        }

        public IEnumerable<Period> GetActivePeriods()
        {
            return baseRepo.Set.Where(e => e.Start < DateTime.Now && e.End > DateTime.Now).Include("Lines").ToList();
        }

        public Period GetPeriod(Guid periodId)
        {
            var period = baseRepo.Set.Include("Lines").FirstOrDefault(e => e.Id == periodId);
            
            return period;
        }

        public IEnumerable<Period> GetPeriods()
        {
            return baseRepo.Set.Include("Lines").ToList();
        }

        public IEnumerable<Period> GetPeriods(DateTime date)
        {
            return baseRepo.Set.Where(e => e.Start > date).Include("Lines").ToList();
        }

        public IEnumerable<Period> GetPeriods(DateTime date, DateTime endDate)
        {
            return baseRepo.Set.Where(e => e.Start > date && e.Start < endDate).Include("Lines").ToList();
        }
    }
}
