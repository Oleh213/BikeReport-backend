using System;
using Microsoft.EntityFrameworkCore;

namespace task_backend.Context
{
    public class ReportContext : DbContext
    {
        public string DbPath { get; set; }

        public ReportContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "database.db");
        }

        public DbSet<Report> Reports { get; set; }

        public DbSet<BikeBrand> BikeBrands { get; set; }

        public DbSet<BikeType> BikeTypes { get; set; }

        public DbSet<ServiceComponent> ServiceComponents { get; set; }

        public DbSet<ServicePackage> ServicePackages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ServicePackage>()
                .HasMany(x => x.Reports)
                .WithMany(x => x.ServicePackeges);

            modelBuilder.Entity<ServiceComponent>()
                .HasMany(x => x.Report)
                .WithOne(x => x.ServiceComponent)
                .HasForeignKey(p => p.ServiceComponentId);

            modelBuilder.Entity<BikeType>()
                .HasMany(x => x.Report)
                .WithOne(x => x.BikeType)
                .HasForeignKey(p => p.BikeTypeId);

            modelBuilder.Entity<BikeBrand>()
                .HasMany(x => x.Report)
                .WithOne(x => x.BikeBrand)
                .HasForeignKey(p => p.BikeBrandId);

            modelBuilder.Entity<Report>().HasKey(s => new { s.ReportId });

            modelBuilder.Entity<BikeBrand>().HasKey(s => new { s.BikeBrandId });

            modelBuilder.Entity<BikeType>().HasKey(s => new { s.BikeTypeId });

            modelBuilder.Entity<ServiceComponent>().HasKey(s => new { s.ServiceComponentId });

            modelBuilder.Entity<ServicePackage>().HasKey(s => new { s.ServicePackageId });


        }
    }
}

