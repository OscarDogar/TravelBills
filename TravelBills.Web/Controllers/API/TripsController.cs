using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccer.Common.Models;
using Soccer.Web.Data.Entities;
using Soccer.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Common.Models;
using TravelBills.Web.Data;
using TravelBills.Web.Data.Entities;
using TravelBills.Web.Helpers;
using TravelBills.Web.Resources;

namespace TravelBills.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IUserHelper _userHelper;

        public TripsController(DataContext context, IConverterHelper converterHelper, IUserHelper userHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            List<TripEntity> trips = await _context.Trips
                                                   .Include(t => t.User)
                                                   .Include(t => t.TripType)
                                                   .Include(t => t.TripDetails)
                                                   .ThenInclude(t => t.TripExpenseType)
                                                   .ToListAsync();
            return Ok(_converterHelper.ToTripResponse(trips));
        }

        [HttpPost]
        public async Task<IActionResult> PostTravel([FromBody] TripRequest TripRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Bad request",
                    Result = ModelState
                });
            }
          
            CultureInfo cultureInfo = new CultureInfo(TripRequest.CultureInfo);
            Resource.Culture = cultureInfo;

            UserEntity userEntity = await _userHelper.GetUserAsync(TripRequest.User);
            if (userEntity == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = Resource.UserDoesntExists
                });
            }

            var TripTypeEntity = await _context.TripTypes.FindAsync(TripRequest.TripType);

            if (TripTypeEntity == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = Resource.TheTripTypeWasNotFound
                });
            }

            TripEntity Trip = new TripEntity
            {
                TripType = await _context.TripTypes.FirstOrDefaultAsync(tt => tt.Id == TripRequest.TripType),
                StartDate = TripRequest.StartDate,
                EndDate = TripRequest.EndDate,
                User = await _context.Users.FirstOrDefaultAsync(u => u.Id == TripRequest.User.ToString()),
                VisitedCity= TripRequest.VisitedCity
            };

            _context.Trips.Add(Trip);
            await _context.SaveChangesAsync();

            return Ok(new Response
            {
                IsSuccess = true,
                Message = Resource.TheTripHasBeenSavedCorrectly
            });

        }

    }
}
