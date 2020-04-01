using Soccer.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Common.Models;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Helpers
{
  public interface IConverterHelper
    {
        TripResponse ToTripResponse(TripEntity tripEntity);

        List<TripResponse> ToTripResponse(List<TripEntity> tripEntities);

        UserResponse ToUserResponse(UserEntity user);
    }
}
