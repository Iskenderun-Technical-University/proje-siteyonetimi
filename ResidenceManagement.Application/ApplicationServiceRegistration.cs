using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ResidenceManagement.Application.FluentValidations.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ResidenceManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
              IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddScoped<BusinessException>();

            #region FluentValidaton Control
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddControllers()
            .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<SignUpUserValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<SignInUserValidator>();

            }
            );

            #endregion

          
            

            return services;
        }
    }
}
