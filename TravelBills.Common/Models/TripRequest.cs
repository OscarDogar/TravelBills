using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelBills.Common.Models
{
  public  class TripRequest
    {
        
        [Required]
        public string VisitedCity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int TripType { get; set; }

        public Guid User { get; set; }

        [Required]
        public string CultureInfo { get; set; }
    }
}
