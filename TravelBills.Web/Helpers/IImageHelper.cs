﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBills.Web.Helpers
{
    public interface IImageHelper
    {
       string UploadImage(byte[] pictureArray, string folder);
    }

}
