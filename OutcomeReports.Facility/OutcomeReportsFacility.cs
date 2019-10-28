using AutoMapper;
using OutcomeReports.ApplicationService.Abstraction;
using OutcomeReports.ApplicationService.Implementation;
using OutcomeReports.Data;
using OutcomeReports.Domain;
using OutcomeReports.Domain.Entities;
using OutcomeReports.Domain.ViewModels;
using OutcomeReports.SharedKernel;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace OutcomeReports.Facility
{
    public class OutcomeReportsFacility: IUnityFacility
    {
        private readonly string sqliteConnectionString;

        public OutcomeReportsFacility(string sqliteConnectionString)
        {
            this.sqliteConnectionString = sqliteConnectionString;
        }

        public void Register(IUnityContainer container)
        {
            var mapper = new MapperConfiguration(cfg=>  
            {
                cfg.CreateMap<Period, PeriodViewModel>().ForMember(p => p.Lines, opt=>opt.MapFrom(s=>s.GetLines())) ;
                cfg.CreateMap<Line, LineViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
            });

            container.RegisterInstance(mapper, new SingletonLifetimeManager());
            container.RegisterType<IOutcomeReportUnitOfWork, OutcomeReportUnitOfWork>(new InjectionConstructor(sqliteConnectionString));
            container.RegisterType<IOutcomeReportService, OutcomeReportService>();
        }
    }
}
