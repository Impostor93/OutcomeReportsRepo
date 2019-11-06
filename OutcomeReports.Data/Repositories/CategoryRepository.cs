namespace OutcomeReports.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OutcomeReports.Domain.Entities;
    using OutcomeReports.Domain.Repositories;

    public class CategoryRepository : ICategoryRepository
    {
        private RepositoryBase<Category> baseRepo;

        public CategoryRepository(OutcomeReportsContext context)
        {
            this.baseRepo = new RepositoryBase<Category>(context);
        }

        public void Create(string name)
        {
            this.baseRepo.Create(new Category() { Name = name });
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.baseRepo.Set.ToList();
        }
    }
}
