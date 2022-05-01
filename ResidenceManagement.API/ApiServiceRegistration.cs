using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ResidenceManagement.API.Consumers;
using ResidenceManagement.Application.CustomExceptions;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Extentions;
using ResidenceManagement.Application.Settings;
using ResidenceManagement.Domain.Entities.Auths;
using ResidenceManagement.Infrastructure.Persistence;
using Shared.Models.Models;
using System;

namespace ResidenceManagement.API
{
    public static class ApiServiceRegistration
    {
        public static object AddApiService(this IServiceCollection services,
             IConfiguration configuration)
        {
            #region Settings

            services.Configure<JwtSettings>(configuration.GetSection("JWT"));
            var jwt = configuration.GetSection("JWT").Get<JwtSettings>();


            #endregion

            #region Kullanıcı şifre kısıtlama
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;

            }).AddEntityFrameworkStores<SiteContext>().AddDefaultTokenProviders();

            #endregion

            services.ConfigureCors();

            services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));

            services.AddAuth(jwt);
            services.AddAuthorization(options =>
            {

                options.AddPolicy("Admin",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Administrators");
                    });

            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();


            });

            services.AddMassTransit(x =>
            {
                x.AddConsumer<PaymentConsumer>();
                x.AddConsumer<PaymentRangeConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cur =>
                {
                    cur.UseHealthCheck(provider);
                    cur.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("admin");
                        h.Password("123456");
                    }); 
                    cur.ReceiveEndpoint("paymentQueue", oq =>
                    {
                        oq.PrefetchCount = 20;
                        //oq.UseMessageRetry(r => r.Interval(2, 100));
                        oq.ConfigureConsumer<PaymentConsumer>(provider);
                    });
                    cur.ReceiveEndpoint("paymentRangeQueue", oq =>
                    {
                        oq.PrefetchCount = 20;
                        //oq.UseMessageRetry(r => r.Interval(2, 100));
                        oq.ConfigureConsumer<PaymentRangeConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();


            return services;
        }

    }
}
