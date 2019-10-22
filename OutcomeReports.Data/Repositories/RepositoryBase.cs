using Microsoft.EntityFrameworkCore;
using OutcomeReports.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutcomeReports.Data.Repositories
{
    internal class RepositoryBase<T> where T : class
    {
        private OutcomeReportsContext context;

        public RepositoryBase(OutcomeReportsContext context)
        {
            this.context = context;
        }

        internal void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        internal void Update(T entity)
        {
            var localEntity = context.Set<T>().Local.FirstOrDefault(e => Equals(entity));
            if (ReferenceEquals(localEntity, null))
            {
                context.Entry(entity);
                context.Set<T>().Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        internal void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        internal DbSet<T> Set { get { return context.Set<T>(); } }
    }
}
