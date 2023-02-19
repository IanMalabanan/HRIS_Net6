using System.Diagnostics;
using System.Reflection;
using Duende.IdentityServer.EntityFramework.Options;
using HRIS.Domain.Entities;
using HRIS.Infrastructure.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HRIS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options,
           IOptionsMonitor<Configurations.DbContextOptions> dbOptions
            ) : base(options)
        {
            var _dbOptions = dbOptions.CurrentValue;
            if (_dbOptions.UseIsolationLevelReadUncommitted)
            {
                Database.OpenConnection();
                Database.ExecuteSqlRaw("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            }
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<DepartmentSection> DepartmentSections { get; set; }

        public DbSet<CustomEmployee> CustomEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
