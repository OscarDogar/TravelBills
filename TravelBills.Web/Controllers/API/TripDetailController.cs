using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccer.Common.Models;
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
    public class TripDetailController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IUserHelper _userHelper;

        public TripDetailController(DataContext context, IConverterHelper converterHelper, IUserHelper userHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _userHelper = userHelper;
        }
        [HttpPost]
        public async Task<IActionResult> PostTravelDetails([FromBody] TripDetailRequest TripDetailRequest)
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
            CultureInfo cultureInfo = new CultureInfo(TripDetailRequest.CultureInfo);
            Resource.Culture = cultureInfo;
            var TripEntity = await _context.Trips.FindAsync(TripDetailRequest.TripId);
            if (TripEntity == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = Resource.ThisTripDoesNotExist
                });
            }

            var typeExpenseEntity = await _context.TripExpenseTypes.FindAsync(TripDetailRequest.TripExpenseTypeId);

            if (typeExpenseEntity == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = Resource.TheTypeExpenseWasNotFound
                });
            }
            var picturePath = "";
            //string picturePath = string.Empty;
            //if (TripDetailRequest.ReceiptPhotoArray != null && TripDetailRequest.ReceiptPhotoArray.Length > 0)
            //{
            //    picturePath = _imageHelper.UploadImage(TripDetailRequest.ReceiptPhotoArray, "TravelDetails");
            //}

            var travelDetail = new TripDetailEntity
            {
                StartDate = TripDetailRequest.StartDate,
                BillValue = TripDetailRequest.BillValue,
                PicturePath = picturePath,
                Trip = await _context.Trips.FirstOrDefaultAsync(u => u.Id == TripDetailRequest.TripId),
                TripExpenseType = await _context.TripExpenseTypes.FirstOrDefaultAsync(c => c.Id == TripDetailRequest.TripExpenseTypeId),
            };

            _context.TripDetails.Add(travelDetail);
            await _context.SaveChangesAsync();

            return Ok(new Response
            {
                IsSuccess = true,
                Message = Resource.TheExpensesOfTheTripHasBeenSaved
            });

        }
    }
}
