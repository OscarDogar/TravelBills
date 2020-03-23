using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBills.Web.Data.Entities
{
    public class TripTypeEntity
    {
        public int Id { get; set; }
       
        [Display(Name = "Type")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Type { get; set; }

        public TripEntity Trip{ get; set; }
    }
}
