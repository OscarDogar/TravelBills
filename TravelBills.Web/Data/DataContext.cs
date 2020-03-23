using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TripEntity> Trips { get; set; }

        public DbSet<TripExpenseTypeEntity> TripExpenseTypes { get; set; }

        public DbSet<TripTypeEntity> TripTypes { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }
    }
}
