using OutcomeReports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Domain.Repositories
{
    public interface ICategoryRepository
    {
        void Create(string Name);

        IEnumerable<Category> GetAllCategories();
    }
}
