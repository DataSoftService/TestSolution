using Acv2.SharedKernel.Infraestructure;
using Acv2.SharedKernel.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace TestSolution.Infrastructure.Database.Communication
{
    public static class DependencyInjection
    {
        public static IUnityContainer AddContainerInfrastructure(this IUnityContainer container)
        {

            container.RegisterType(typeof(IQueryableUnitOfWork), typeof(SharedDbContext));


            container.RegisterType(typeof(DbContext), typeof(SharedDbContext));
            container.RegisterType(typeof(IQueryableUnitOfWork), typeof(DbContext));
            container.RegisterType(typeof(SharedDbContext), typeof(DbContext));

            return container;
        }

        public static IServiceCollection AddServiceInfraestruturaGeneral(this IServiceCollection service)
        {
            return service;
        }
    }
}
