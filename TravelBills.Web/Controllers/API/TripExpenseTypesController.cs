using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBills.Web.Data;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Controllers.API
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TripExpenseTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public TripExpenseTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TripExpenseTypes
        [HttpGet]
        public IEnumerable<TripExpenseTypeEntity> GetTripExpenseTypes()
        {
            return _context.TripExpenseTypes.OrderBy(t => t.Type);
        }

        // GET: api/TripExpenseTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripExpenseTypeEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripExpenseTypeEntity = await _context.TripExpenseTypes.FindAsync(id);

            if (tripExpenseTypeEntity == null)
            {
                return NotFound();
            }

            return Ok(tripExpenseTypeEntity);
        }
    }
}