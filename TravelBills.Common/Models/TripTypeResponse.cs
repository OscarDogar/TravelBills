using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBills.Common.Models
{
    public class TripTypeResponse
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<TripResponse> Trips { get; set; }
    }
}
