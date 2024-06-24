using Business.Implementation;
using Business.Interface;
using DataRepository;
using DataRepository.Implementation;
using DataRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServiceDependencies(this IServiceCollection services)
        {
            services.AddDataRepositoryDependencies();
            services.AddBusinessDependecies();
            services.AddServiceDependencies();
            services.AddBusinessDependecies2();
            return services;
        }

        public static IServiceCollection AddDataRepositoryDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryData, RepositoryData>();
            return services;
        }
        
        public static IServiceCollection AddBusinessDependecies(this IServiceCollection services)
        {
            services.AddTransient<ILogicEmailFile, LogicEmailFile>();
            return services;
        }

        public static IServiceCollection AddBusinessDependecies2(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
        
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ContextMain>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("DataSource") ?? "");
            });
            return services;
        }
    }
}
