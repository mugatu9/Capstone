﻿using CSD480Group3Capstone001.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Data
{
    public class PropertyManagementContext : DbContext
    {
        public PropertyManagementContext(DbContextOptions<PropertyManagementContext> options) : base(options)
        {

        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Infraction> Infractions { get; set; }
        public DbSet<RentPayment> RentPayments { get; set; }
        public DbSet<RepairHistory> RepairHistories { get; set; }
        public DbSet<TaxParcel> TaxParcels { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Contractor>().ToTable("Contractor");
            modelBuilder.Entity<Infraction>().ToTable("Infraction");
            modelBuilder.Entity<RentPayment>().ToTable("RentPayment");
            modelBuilder.Entity<RepairHistory>().ToTable("RepairHistory");
            modelBuilder.Entity<TaxParcel>().ToTable("TaxParcel");
            modelBuilder.Entity<Tenant>().ToTable("Tenant");
            modelBuilder.Entity<Unit>().ToTable("Unit");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
        }
    }
}
