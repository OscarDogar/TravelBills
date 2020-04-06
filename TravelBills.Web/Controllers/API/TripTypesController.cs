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
    public class TripTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public TripTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TripTypes
        [HttpGet]
        public IEnumerable<TripTypeEntity> GetTripTypes()
        {
            return _context.TripTypes.OrderBy(t => t.Type);
        }

        // GET: api/TripTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripTypeEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripTypeEntity = await _context.TripTypes.FindAsync(id);

            if (tripTypeEntity == null)
            {
                return NotFound();
            }

            return Ok(tripTypeEntity);
        }
    }
}