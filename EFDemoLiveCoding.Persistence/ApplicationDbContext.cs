using EFDemoLiveCoding.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace EFDemoLiveCoding.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions options) : base(options)
        //{

        //}

        public ApplicationDbContext() { }

        public DbSet<Driver> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true, true);

            var configuration = builder.Build();
            string connectionString = configuration["ConnectionString:DefaultConnection"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
