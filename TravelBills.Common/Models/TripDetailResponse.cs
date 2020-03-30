using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBills.Common.Models
{
   public class TripDetailResponse
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public string PicturePath { get; set; }

        public float BillValue { get; set; }

        public TripExpenseTypeResponse TripExpenseType { get; set; }

        public TripResponse Trip { get; set; }

        public string PictureFullPath => string.IsNullOrEmpty(PicturePath)
    ? "https://travelbillsweb.azurewebsites.net//images/noimage.png"
    : $"https://travelbillsweb.azurewebsites.net{PicturePath.Substring(1)}";

    }
}
