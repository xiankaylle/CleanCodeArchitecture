using App.Core.Queries;
using App.Shared.Contracts;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Core
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            //Mapster Confgiguration
            var typeAdapterConfig = new TypeAdapterConfig();
            // scans the assembly and gets the IRegister
            var mappingRegistrations = TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            // adds the registration to the TypeAdapterConfig
            mappingRegistrations.ToList().ForEach(register => register.Register(typeAdapterConfig));
            // register the mapper as Singleton service for this application
            var mapperConfig = new Mapper(typeAdapterConfig);

            services.AddSingleton<IMapper>(mapperConfig);

            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(typeof(App.Core.AssemblyReference).Assembly);

            var applicationAssembly = typeof(App.Core.AssemblyReference).Assembly;

            services.AddMediatR(applicationAssembly);

            return services;
        }

    }
}