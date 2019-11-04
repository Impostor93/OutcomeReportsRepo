namespace OutcomeReports.ApplicationService.Abstraction
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IOutcomeReportCategoryServiceProvider
    {
        IOutcomeReportCategoryService GetService();
    }
}
