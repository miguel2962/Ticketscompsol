using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tickets.Data;
using Tickets.Data.Entities;

namespace Tickets.Controllers
{
    public class WorkTypesController : Controller
    {
        private readonly DataContext _context;

        public WorkTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: WorkTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkTypes.ToListAsync());
        }

        // GET: WorkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkTypes == null)
            {
                return NotFound();
            }

            var workType = await _context.WorkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workType == null)
            {
                return NotFound();
            }

            return View(workType);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkType workType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workType);
        }

        // GET: WorkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkTypes == null)
            {
                return NotFound();
            }

            var workType = await _context.WorkTypes.FindAsync(id);
            if (workType == null)
            {
                return NotFound();
            }
            return View(workType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkType workType)
        {
            if (id != workType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkTypeExists(workType.Id))
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
            return View(workType);
        }

        // GET: WorkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkTypes == null)
            {
                return NotFound();
            }

            var workType = await _context.WorkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workType == null)
            {
                return NotFound();
            }

            return View(workType);
        }

        // POST: WorkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkTypes == null)
            {
                return Problem("Entity set 'DataContext.WorkTypes'  is null.");
            }
            var workType = await _context.WorkTypes.FindAsync(id);
            if (workType != null)
            {
                _context.WorkTypes.Remove(workType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkTypeExists(int id)
        {
          return _context.WorkTypes.Any(e => e.Id == id);
        }
    }
}
