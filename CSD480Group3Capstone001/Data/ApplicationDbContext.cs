using System;
using System.Collections.Generic;
using System.Text;
using CSD480Group3Capstone001.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSD480Group3Capstone001.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Infraction> Infractions { get; set; }
        public DbSet<RentPayment> RentPayments { get; set; }
        public DbSet<RepairHistory> RepairHistories { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantUnit> TenantUnits { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Contractor>().ToTable("Contractor");
            modelBuilder.Entity<Infraction>().ToTable("Infraction");
            modelBuilder.Entity<RentPayment>().ToTable("RentPayment");
            modelBuilder.Entity<RepairHistory>().ToTable("RepairHistory");
            modelBuilder.Entity<Tenant>().ToTable("Tenant");
            modelBuilder.Entity<TenantUnit>().ToTable("TenantUnits");
            modelBuilder.Entity<Unit>().ToTable("Unit");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");

            modelBuilder.Entity<TenantUnit>()
               .HasKey(o => new { o.TenantID, o.UnitID});
        }
    }
}
