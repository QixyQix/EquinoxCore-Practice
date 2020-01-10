using EquinoxCore.Application.Interfaces;
using EquinoxCore.Application.Services;
using EquinoxCore.Domain.CommandHandlers;
using EquinoxCore.Domain.Commands;
using EquinoxCore.Domain.Core.Bus;
using EquinoxCore.Domain.Core.Events;
using EquinoxCore.Domain.Core.Notifications;
using EquinoxCore.Domain.EventHandlers;
using EquinoxCore.Domain.Events;
using EquinoxCore.Domain.Interfaces;
using EquinoxCore.Infra.CrossCutting.Bus;
using EquinoxCore.Infra.CrossCutting.Identity.Authorization;
using EquinoxCore.Infra.CrossCutting.Identity.Models;
using EquinoxCore.Infra.CrossCutting.Identity.Services;
using EquinoxCore.Infra.Data.Context;
using EquinoxCore.Infra.Data.EventSourcing;
using EquinoxCore.Infra.Data.Repository;
using EquinoxCore.Infra.Data.Repository.EventSourcing;
using EquinoxCore.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EquinoxCore.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services) {
            //ASP.NET HttpContext Dependency
            //Singleton - only one can be instantiated and running at one time
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Domain Bus (Meidator)
            //Scoped - it can create multiple instances of itself, but every one of them are the same
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //ASP.NET Authorization Services
            services.AddSingleton<IAuthorizationHandler, ClaimRequirementHandler>();

            //Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            //Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EquinoxContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, EmailMessageSender>();
            services.AddTransient<ISmsSender, SmsMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();


        }
    }
}
