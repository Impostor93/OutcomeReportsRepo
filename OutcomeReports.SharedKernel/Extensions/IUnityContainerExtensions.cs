using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace OutcomeReports.SharedKernel.Extensions
{
    public static class IUnityContainerExtensions
    {
        public static void AddFacility(this IUnityContainer container, IUnityFacility facility)
        {
            facility.Register(container);
        }
    }
}
