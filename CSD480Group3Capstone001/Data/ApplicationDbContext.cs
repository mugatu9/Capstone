using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CSD480Group3Capstone001.Models;

namespace CSD480Group3Capstone001.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CSD480Group3Capstone001.Models.Tenant> Tenant { get; set; }
        public DbSet<CSD480Group3Capstone001.Models.Vehicle> Vehicle { get; set; }
    }
}
