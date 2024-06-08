using DomainEntities.DBEntities;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.IRepository;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class IOContainer
    {

        public static void ConfigureIOC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
