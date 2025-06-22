using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rubrica.Application.Interfaces;
using Rubrica.Infrastructure.Data;
using Rubrica.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configure all the DI of this project
        /// </summary>
        /// <param name="services"> Services configurator used in Program.cs </param>
        /// <param name="connectionString"> if null or empty DBContext configuration will be skipped </param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInfrastructureDipendencyInjection(this IServiceCollection services, string? connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
                services.AddDbContext<RubricaDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }
    }
}
