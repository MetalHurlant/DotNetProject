using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISEN.DotNet.Library.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ISEN.DotNet.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Voyage> VoyageCollection { get; set; }
        public DbSet<Person> PersonCollection { get; set; }
        public DbSet<Booking> BookingCollection { get; set; }
        public DbSet<Driver> DriverCollection { get; set; }
        public DbSet<Passenger> PassengerCollection { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
                       

            builder.Entity<Person>()
                .ToTable("Person");

            builder.Entity<Driver>()
                .ToTable("Driver");

            builder.Entity<Passenger>()
                .ToTable("Passenger");

            
            builder.Entity<Voyage>()
                .ToTable("Voyage");

            builder.Entity<Booking>()
                .ToTable("Booking");

        }
    }

    public class TempDbContextFactory :
        IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var dbContextBuilder = 
                new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextBuilder.UseSqlite("DataSource=MyWebApp.db");
            return new ApplicationDbContext(dbContextBuilder.Options);
        }
    }
}
