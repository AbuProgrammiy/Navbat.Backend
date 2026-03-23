using Microsoft.Extensions.DependencyInjection;
using Navbat.Application.Services.AuthService;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Navbat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services here

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
