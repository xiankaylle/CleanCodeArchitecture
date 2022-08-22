
using App.Shared.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace App.Shared
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {

         

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            /*
              To enable .Scan install
              dotnet add package Scrutor --version 4.2.0
              ===================================================
              What is Scrutor?
              Scrutor is an open source library that adds assembly scanning capabilities to the ASP.Net Core DI container
            */
            services.Scan(scan => scan
                           .FromApplicationDependencies()
                           .AddClasses(classes => classes.AssignableTo<IValidationHandler>())
                           .AsImplementedInterfaces()
                           .WithTransientLifetime());


            return services;
        }
    }
}