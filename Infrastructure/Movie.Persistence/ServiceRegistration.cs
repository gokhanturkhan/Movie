using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Interfaces.Repository;
using Movie.Application.Interfaces.Services;
using Movie.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddSingleton<IFilmService, EfFilmService>();
            services.AddSingleton<ISalonService, EfSalonService>();
            services.AddSingleton<IFilmSalonService, EfFilmSalonService>();
            services.AddSingleton<IUserService, EfUserService>();
        }
    }
}
