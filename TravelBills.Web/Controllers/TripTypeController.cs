using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBills.Web.Data;
using TravelBills.Web.Data.Entities;

namespace TravelBills.Web.Controllers
{
    public class TripTypeController : Controller
    {
        private readonly DataContext _context;

        public TripTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: TripType
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripTypes.ToListAsync());
        }

        // GET: TripType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] TripTypeEntity tripTypeEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripTypeEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripTypeEntity);
        }

        // GET: TripType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripTypeEntity = await _context.TripTypes.FindAsync(id);
            if (tripTypeEntity == null)
            {
                return NotFound();
            }
            return View(tripTypeEntity);
        }

        // POST: TripType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] TripTypeEntity tripTypeEntity)
        {
            if (id != tripTypeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripTypeEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripTypeEntityExists(tripTypeEntity.Id))
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
            return View(tripTypeEntity);
        }

        // GET: TripType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripTypeEntity = await _context.TripTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripTypeEntity == null)
            {
                return NotFound();
            }

            _context.TripTypes.Remove(tripTypeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripTypeEntityExists(int id)
        {
            return _context.TripTypes.Any(e => e.Id == id);
        }
    }
}
