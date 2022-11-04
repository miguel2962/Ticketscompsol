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
    public class ClienteTypesController : Controller
    {
        private readonly DataContext _context;

        public ClienteTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: ClienteTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ClienteType.ToListAsync());
        }

        // GET: ClienteTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClienteType == null)
            {
                return NotFound();
            }

            var clienteType = await _context.ClienteType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteType == null)
            {
                return NotFound();
            }

            return View(clienteType);
        }

        // GET: ClienteTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ClienteType clienteType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteType);
        }

        // GET: ClienteTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClienteType == null)
            {
                return NotFound();
            }

            var clienteType = await _context.ClienteType.FindAsync(id);
            if (clienteType == null)
            {
                return NotFound();
            }
            return View(clienteType);
        }

        // POST: ClienteTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteType clienteType)
        {
            if (id != clienteType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteTypeExists(clienteType.Id))
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
            return View(clienteType);
        }

        // GET: ClienteTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClienteType == null)
            {
                return NotFound();
            }

            var clienteType = await _context.ClienteType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteType == null)
            {
                return NotFound();
            }

            return View(clienteType);
        }

        // POST: ClienteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClienteType == null)
            {
                return Problem("Entity set 'DataContext.ClienteType'  is null.");
            }
            var clienteType = await _context.ClienteType.FindAsync(id);
            if (clienteType != null)
            {
                _context.ClienteType.Remove(clienteType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteTypeExists(int id)
        {
          return _context.ClienteType.Any(e => e.Id == id);
        }
    }
}
