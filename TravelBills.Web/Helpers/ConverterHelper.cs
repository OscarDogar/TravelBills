using Soccer.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Common.Models;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        
        public TripResponse ToTripResponse(TripEntity tripEntity)
        {
            return new TripResponse
            {
                EndDate = tripEntity.EndDate,
                Id = tripEntity.Id,
                StartDate = tripEntity.StartDate,
                VisitedCity = tripEntity.VisitedCity,
                TripType = ToTripTypeResponse(tripEntity.TripType),
                User = ToUserResponse(tripEntity.User),
                TripDetails = tripEntity.TripDetails.Select(td => new TripDetailResponse
                {
                    Id = td.Id,
                    StartDate = td.StartDate,
                    PicturePath = td.PicturePath,
                    BillValue = td.BillValue,
                    TripExpenseType = ToTripExpenseTypeResponse(td.TripExpenseType),
                    Trip= ToTripResponseInTripDetails(td.Trip)
                }).ToList()
            };
        }

        public List<TripResponse> ToTripResponse(List<TripEntity> TripEntities)
        {
            List<TripResponse> list = new List<TripResponse>();
            foreach (TripEntity TripEntity in TripEntities)
            {
                list.Add(ToTripResponse(TripEntity));
            }

            return list;
        }

        private UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType
            };
        }
        private TripResponse ToTripResponseInTripDetails(TripEntity Trip)
        {
            if (Trip == null)
            {
                return null;
            }

            return new TripResponse
            {
                Id = Trip.Id
            };
        }
        private TripExpenseTypeResponse ToTripExpenseTypeResponse(TripExpenseTypeEntity TripExpenseType)
        {
            if (TripExpenseType == null)
            {
                return null;
            }

            return new TripExpenseTypeResponse
            {
                Id = TripExpenseType.Id,
                Type = TripExpenseType.Type
            };
        }

        private TripTypeResponse ToTripTypeResponse(TripTypeEntity TripType)
        {
            if (TripType == null)
            {
                return null;
            }

            return new TripTypeResponse
            {
                Id = TripType.Id,
                Type = TripType.Type
            };
        }
    }
}
