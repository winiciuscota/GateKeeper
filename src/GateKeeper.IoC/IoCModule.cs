using Autofac;
using GateKeeper.Data;
using GateKeeper.Data.Context;
using GateKeeper.Data.Repositories;
using GateKeeper.Domain.Repositories.Interfaces;

namespace GateKeeper.IoC
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Services
            builder.RegisterType<ResidentRepository>().As<IResidentRepository>();

            builder.RegisterType<GateKeeperDbContext>();
        }
    }
}