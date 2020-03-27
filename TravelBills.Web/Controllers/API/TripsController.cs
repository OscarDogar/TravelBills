using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Web.Data;
using TravelBills.Web.Data.Entities;
using TravelBills.Web.Helpers;

namespace TravelBills.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public TripsController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
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

    }
}
