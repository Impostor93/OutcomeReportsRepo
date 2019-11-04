namespace OutcomeReports.Facility
{
    using OutcomeReports.ApplicationService.Abstraction;
    using Unity;

    public class DefaultOutcomeCategoryServiceProvider : IOutcomeReportCategoryServiceProvider
    {
        private readonly IUnityContainer container;

        public DefaultOutcomeCategoryServiceProvider(IUnityContainer container)
        {
            this.container = container;
        }

        public IOutcomeReportCategoryService GetService()
        {
            return container.Resolve<IOutcomeReportCategoryService>();
        }
    }
}
