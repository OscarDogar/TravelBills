using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelBills.Common.Models
{
    public class TripDetailRequest
    {

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public float BillValue { get; set; }

        public int TripExpenseTypeId { get; set; }

        public byte[] PictureArray { get; set; }

        public int TripId { get; set; }

        [Required]
        public string CultureInfo { get; set; }
    }
}
