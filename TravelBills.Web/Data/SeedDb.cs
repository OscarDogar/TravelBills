using Soccer.Common.Enums;
using Soccer.Web.Data.Entities;
using Soccer.Web.Helpers;
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
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Oscar", "Doria", "oscardoria14@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            await CheckUserAsync("2020", "Vincenzo", "Corleone", "elpadrino@hotmail.com", "350 634 2747", "Calle Luna Italia", UserType.Employee);
            await CheckTripTypesAsync();
            await CheckTripExpenseTypeAsync();
            await CheckTripsAsync();
           }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Employee.ToString());
        }

        private async Task<UserEntity> CheckUserAsync(string document,
                                                      string firstName,
                                                      string lastName,
                                                      string email,
                                                      string phone,
                                                      string address,
                                                      UserType userType)
        {
            UserEntity user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
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
            _context.TripExpenseTypes.Add(new TripExpenseTypeEntity { Type = name });
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
            _context.TripTypes.Add(new TripTypeEntity { Type = name });
        }

        private async Task CheckTripsAsync()
        {
            if (!_context.Trips.Any())
            {
                DateTime startDate = DateTime.Today.AddMonths(1).ToUniversalTime();
                DateTime endDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                DateTime startDateToTripDetails = DateTime.Today.AddMonths(1).AddDays(3).ToUniversalTime();
                _context.Trips.Add(new TripEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    VisitedCity = "Medellin",
                    TripType = _context.TripTypes.FirstOrDefault(t => t.Type == "Get the visa"),
                    User = _context.Users.FirstOrDefault(),
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
                    User = _context.Users.FirstOrDefault(),
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
                    User = _context.Users.FirstOrDefault(),
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
