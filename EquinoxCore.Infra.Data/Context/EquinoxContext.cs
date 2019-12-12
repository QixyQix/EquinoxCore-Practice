using System;
using System.Collections.Generic;
using System.Text;
using EquinoxCore.Domain.Models;
using EquinoxCore.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EquinoxCore.Infra.Data.Context
{
    public class EquinoxContext : DbContext
    {
        public IHostEnvironment _env { get; set; }

        public EquinoxContext(IHostEnvironment env)
        {
            _env = env;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //Get appsettings.json config
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            //Set the database to use
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        }

    }
}
