using Microsoft.AspNetCore.Mvc.Rendering;
using Soccer.Web.Data;
using System.Collections.Generic;
using System.Linq;
using TravelBills.Web.Data;

namespace Soccer.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboTripType()
        {
            List<SelectListItem> list = _context.TripTypes.Select(t => new SelectListItem
            {
                Text = t.Type,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a team...]",
                Value = "0"
            });

            return list;
        }
        public IEnumerable<SelectListItem> GetComboTripExpenseType()
        {
            List<SelectListItem> list = _context.TripExpenseTypes.Select(t => new SelectListItem
            {
                Text = t.Type,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a team...]",
                Value = "0"
            });

            return list;
        }
    }
}
