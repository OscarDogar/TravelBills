using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBills.Web.Data;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class TripExpenseTypeController : Controller
    {
        private readonly DataContext _context;

        public TripExpenseTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: TripExpenseType
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripExpenseTypes.ToListAsync());
        }

        // GET: TripExpenseType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripExpenseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripExpenseTypeEntity tripExpenseTypeEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripExpenseTypeEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There is already a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(tripExpenseTypeEntity);
        }

        // GET: TripExpenseType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripExpenseTypeEntity = await _context.TripExpenseTypes.FindAsync(id);
            if (tripExpenseTypeEntity == null)
            {
                return NotFound();
            }
            return View(tripExpenseTypeEntity);
        }

        // POST: TripExpenseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] TripExpenseTypeEntity tripExpenseTypeEntity)
        {
            if (id != tripExpenseTypeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripExpenseTypeEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExpenseTypeEntityExists(tripExpenseTypeEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tripExpenseTypeEntity);
        }

        // GET: TripExpenseType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripExpenseTypeEntity = await _context.TripExpenseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripExpenseTypeEntity == null)
            {
                return NotFound();
            }

            _context.TripExpenseTypes.Remove(tripExpenseTypeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExpenseTypeEntityExists(int id)
        {
            return _context.TripExpenseTypes.Any(e => e.Id == id);
        }
    }
}
