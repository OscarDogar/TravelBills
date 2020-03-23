using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace TravelBills.Web.Data.Entities
{
    public class TripDetailEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Time { get; set; }

        [Display(Name = "Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime TimeLocal => Time.ToLocalTime();

        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Bill Value")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public float BillValue { get; set; }

        public ICollection<TripExpenseTypeEntity> TripExpenseTypes { get; set; }

        public TripEntity Trip{ get; set; }
    }
}
