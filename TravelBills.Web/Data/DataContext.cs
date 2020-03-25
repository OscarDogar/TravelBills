using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TripEntity> Trips { get; set; }

        public DbSet<TripExpenseTypeEntity> TripExpenseTypes { get; set; }

        public DbSet<TripTypeEntity> TripTypes { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TripExpenseTypeEntity>()
                   .HasIndex(t => t.Type)
                   .IsUnique();
            modelBuilder.Entity<TripTypeEntity>()
                   .HasIndex(t => t.Type)
                   .IsUnique();
        }
       
    }
}
