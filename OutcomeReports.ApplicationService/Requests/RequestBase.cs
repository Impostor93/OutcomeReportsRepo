using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.ApplicationService
{
    public class RequestBase
    {
        public RequestBase()
        {
            ShouldDisposeContext = true;
        }

        public bool ShouldDisposeContext { get; private set; }
    }
}
