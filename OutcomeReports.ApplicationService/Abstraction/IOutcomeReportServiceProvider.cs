using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.ApplicationService.Abstraction
{
    public interface IOutcomeReportServiceProvider
    {
        IOutcomeReportService GetService();
    }
}
