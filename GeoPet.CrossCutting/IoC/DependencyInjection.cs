using GeoPet.Application.Interfaces;
using GeoPet.Application.Mappings;
using GeoPet.Application.Services;
using GeoPet.Domain.Interfaces;
using GeoPet.Infrastructure.Context;
using GeoPet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeoPet.CrossCutting.IoC;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            // services.AddDbContext<ApplicationDbContext>(options =>
            // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            // ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            //          new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddScoped<IPetOwnerRepository, PetOwnerRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetOwnerService, PetOwnerService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
