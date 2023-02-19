using AutoMapper.Configuration;
using HRIS.Application.Common.Interfaces;
using HRIS.Application.Common.Interfaces.Application;
using HRIS.Application.Common.Interfaces.Repositories;
using HRIS.Application.Common.Models;
using HRIS.Infrastructure.Configurations;
using HRIS.Infrastructure.HTTPClientHandlers;
using HRIS.Infrastructure.Identity;
using HRIS.Infrastructure.Persistence.Repositories;
using HRIS.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.OpenApi.Models;
using Duende.IdentityServer.Models;
using HRIS.Application.Common.Exceptions;
using HRIS.Net6_CQRSApproach.Model;
using HRIS.Application.Common.Interfaces.Services;

namespace HRIS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<HttpClient>();

            //Services
            services.AddScoped<IDateTime, DateTimeService>();
            services.AddSingleton<IApp, AppOptions>();
            services.AddTransient<IIdentityService, IdentityService>();

            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICustomEmployeeRepository, CustomEmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentalSectionRepository,DepartmentalSectionRepository>();


            return services;
        }
    }
}
