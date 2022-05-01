using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.API.Data.Persistence;
using PaymentService.API.Repositories;
using MassTransit;
using System;
using System.Reflection;
using MediatR;
using PaymentService.API.Extensions;

namespace PaymentService.API
{
    public static class PaymentApiServiceRegistration
    {
        public static IServiceCollection AddPaymentApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ICardContext, CardContext>();
            services.AddScoped<ICardRepository, CardRepository>();
            
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.UseHealthCheck(provider);
                    config.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("admin");
                        h.Password("123456");
                    });
                }));
            });
            services.AddMassTransitHostedService();
            //services.ConfigureCors();


            return services;
        }
    }
}
