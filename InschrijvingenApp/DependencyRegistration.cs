using InschrijvingPietieterken.Business;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}
