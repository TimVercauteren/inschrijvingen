using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvenPietieterken.Shared
{
    public class AppSettings
    {

        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }

        public static void RegisterConfiguration(IServiceCollection services, IConfigurationSection section)
        {
            services.Configure<AppSettings>(settings =>
            {
                settings.LoadFromConfigSection(section);
            });
        }

        private void LoadFromConfigSection(IConfigurationSection section)
        {
            section.Bind(this);
        }
    }
}
