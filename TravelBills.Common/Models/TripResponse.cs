using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBills.Common.Models
{
   public class TripResponse
    {
        public int Id { get; set; }

        public string VisitedCity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public DateTime EndDate { get; set; }

        public DateTime EndDateLocal => EndDate.ToLocalTime();

        public TripTypeResponse TripType { get; set; }

        public UserResponse User { get; set; }

        public ICollection<TripDetailResponse> TripDetails { get; set; }
    }
}
