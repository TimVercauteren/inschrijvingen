using DataAccess;
using DataAccess.Uow;
using InschrijvingPietieterken.Business;
using InschrijvingPietieterken.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvingPietieterken
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //business classes

            services.AddScoped<IDataProcessor, DataProcessor>();
            services.AddScoped<IInschrijvingsProcessor, InschrijvingsProcessor>();
            services.AddScoped<IAttachmentProcessor, AttachmentProcessor>();
            services.AddScoped<ILoginManager, LoginManager>();

            //Data Access Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, EntityContext>();


            return services;
        }
    }
}
