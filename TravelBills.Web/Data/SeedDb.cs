using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTripTypesAsync();
            await CheckTripExpenseTypeAsync();
            await CheckTripsAsync();
        }

        private async Task CheckTripExpenseTypeAsync()
        {
            if (!_context.TripExpenseTypes.Any())
            {
                AddTripExpenseType("Transportation");
                AddTripExpenseType("Food");
                AddTripExpenseType("Drinks");
                AddTripExpenseType("Hotel");
                AddTripExpenseType("Ticket");
                await _context.SaveChangesAsync();
            }

        }
        private void AddTripExpenseType(string name)
        {
            _context.TripExpenseTypes.Add(new TripExpenseTypeEntity { Type = name});
        }


        private async Task CheckTripTypesAsync()
        {
            if (!_context.TripTypes.Any())
            {
                AddTripType("Get the visa");
                AddTripType("International trip");
                AddTripType("Home center customer visit");
                AddTripType("Consultancy");
                AddTripType("Local Trip");
                await _context.SaveChangesAsync();
            }
        }
        private void AddTripType(string name)
        {
            _context.TripTypes.Add(new TripTypeEntity { Type = name});
        }

        private async Task CheckTripsAsync()
        {
            if (!_context.Trips.Any())
            {
                var startDate = DateTime.Today.AddMonths(1).ToUniversalTime();
                var endDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                var startDateToTripDetails = DateTime.Today.AddMonths(1).AddDays(3).ToUniversalTime();
                _context.Trips.Add(new TripEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    VisitedCity = "Medellin",
                    TripType = _context.TripTypes.FirstOrDefault(t => t.Type == "Get the visa"),
                    TripDetails = new List<TripDetailEntity>
                    {
                         new TripDetailEntity
                        {
                             StartDate=startDateToTripDetails,
                             PicturePath = $"~/images/BillsPictures/factura.png",
                             BillValue=5000,
                             TripExpenseType = _context.TripExpenseTypes.FirstOrDefault(t => t.Type == "Hotel")
                        }
                    }
                });
                startDate = DateTime.Today.AddMonths(1).ToUniversalTime();
                endDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                startDateToTripDetails = DateTime.Today.AddMonths(1).AddDays(3).ToUniversalTime();
                _context.Trips.Add(new TripEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    VisitedCity = "Bogota",
                    TripType = _context.TripTypes.FirstOrDefault(t => t.Type == "Local trip"),
                    TripDetails = new List<TripDetailEntity>
                    {
                         new TripDetailEntity
                        {
                             StartDate=startDateToTripDetails,
                             PicturePath = $"~/images/BillsPictures/factura.png",
                             BillValue=78000,
                             TripExpenseType = _context.TripExpenseTypes.FirstOrDefault(t => t.Type == "Transportation")
                        }
                    }
                });
                startDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                endDate = DateTime.Today.AddMonths(3).ToUniversalTime();
                startDateToTripDetails = DateTime.Today.AddMonths(1).AddDays(3).ToUniversalTime();
                _context.Trips.Add(new TripEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    VisitedCity = "Madrid",
                    TripType = _context.TripTypes.FirstOrDefault(t => t.Type == "International trip"),
                    TripDetails = new List<TripDetailEntity>
                    {
                         new TripDetailEntity
                        {
                             StartDate=startDateToTripDetails,
                             PicturePath = $"~/images/BillsPictures/factura2.png",
                             BillValue=78000,
                             TripExpenseType = _context.TripExpenseTypes.FirstOrDefault(t => t.Type == "Ticket")
                        },
                          new TripDetailEntity
                        {
                             StartDate=startDateToTripDetails,
                             PicturePath = $"~/images/BillsPictures/factura2.png",
                             BillValue=16000,
                             TripExpenseType = _context.TripExpenseTypes.FirstOrDefault(t => t.Type == "Food")
                        }
                    }
                });
            }
            await _context.SaveChangesAsync();
        }

    }
}
