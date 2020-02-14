using FCamara.Domain.Contracts;
using FCamara.Infra.Contexts;
using FCamara.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FCamara.Application.Commands;
using FCamara.Application.Commands.Transaction;
using FCamara.Application.Core;
using System;

namespace FCamara.IOC
{
    public static class NativeDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();
            services.AddDataServices();
            services.RegisterCommands();
            services.AddMediatr();

            return services;
        }

        public static void RegisterCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateAccount));
            services.AddMediatR(typeof(CreateTransaction));
        }

        public static void AddServices(this IServiceCollection services)
        {}

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<FCContext>(opt=> opt.UseInMemoryDatabase("FCamara"));
        }

        private static void AddMediatr(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("FCamara.Application");
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestsValidationMiddleware<,>));
            services.AddMediatR(assembly);
        }
    }
}
