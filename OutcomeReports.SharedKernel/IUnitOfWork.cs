using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.SharedKernel
{
    public interface IUnitOfWork : IDisposable
    {
        public void Commit();
    }
}
