using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Contracts.Repositories.Commons;
using ResidenceManagement.Infrastructure.Contracts.Repositories;
using ResidenceManagement.Infrastructure.Contracts.Repositories.Commons;
using ResidenceManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnectionString");
            //string mySqliteStr = configuration.GetConnectionString("Data Source = ..//site.db");


            services.AddDbContext<SiteContext>(options =>
                                             //options.UseSqlite("Data Source = site.db"));
            options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString")));
            //options.UseSqlServer(mySqlConnectionStr));


            //#region Commons

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IResidenceRepository, ResidenceRepository>();
            services.AddScoped<IUserResidenceRepository, UserResidenceRepository>();
            services.AddScoped<IDuesRepository, DuesRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IResidenceDuesRepository, ResidenceDuesRepository>();
            services.AddScoped<IResidenceInvoiceRepository, ResidenceInvoiceRepository>();



            //#endregion

            //#region Caching

            //services.AddTransient<ICacheService, MemoryCacheService>();

            //#endregion




            return services;
        }
    }
}
