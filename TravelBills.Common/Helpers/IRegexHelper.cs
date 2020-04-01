using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBills.Common.Helpers
{
    public interface IRegexHelper
    {
        bool IsValidEmail(string emailaddress);
    }
}
