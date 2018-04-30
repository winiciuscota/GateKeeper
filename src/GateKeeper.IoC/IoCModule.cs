using Autofac;
using GateKeeper.Data;
using GateKeeper.Data.Context;
using GateKeeper.Data.Repositories;
using GateKeeper.Domain;
using GateKeeper.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GateKeeper.IoC
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Repositories
            builder.RegisterType<ResidentRepository>().As<IResidentRepository>();

            // Unit of work
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // DbContext
            builder.RegisterType<GateKeeperDbContext>().SingleInstance();
        }
    }
}