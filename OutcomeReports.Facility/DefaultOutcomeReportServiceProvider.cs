using OutcomeReports.ApplicationService.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace OutcomeReports.Facility
{
    public class DefaultOutcomeReportServiceProvider : IOutcomeReportServiceProvider
    {
        private readonly IUnityContainer container;

        public DefaultOutcomeReportServiceProvider(IUnityContainer container)
        {
            this.container = container;
        }

        public IOutcomeReportService GetService()
        {
            return container.Resolve<IOutcomeReportService>();
        }
    }
}
