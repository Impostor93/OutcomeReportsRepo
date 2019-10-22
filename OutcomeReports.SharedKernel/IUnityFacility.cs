using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace OutcomeReports.SharedKernel
{
    public interface IUnityFacility
    {
        void Register(IUnityContainer container);
    }
}
