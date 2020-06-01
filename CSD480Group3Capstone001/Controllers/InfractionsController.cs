using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSD480Group3Capstone001.Data;
using CSD480Group3Capstone001.Models;

namespace CSD480Group3Capstone001.Controllers
{
    public class InfractionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Infractions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Infractions.Include(i => i.Tenant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Infractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infraction = await _context.Infractions
                .Include(i => i.Tenant)
                .FirstOrDefaultAsync(m => m.InfractionID == id);
            if (infraction == null)
            {
                return NotFound();
            }

            return View(infraction);
        }

        // GET: Infractions/Create
        public IActionResult Create()
        {
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID");
            return View();
        }

        // POST: Infractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InfractionID,TenantID,Date,Reason,Amount,Paid")] Infraction infraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", infraction.TenantID);
            return View(infraction);
        }

        // GET: Infractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infraction = await _context.Infractions.FindAsync(id);
            if (infraction == null)
            {
                return NotFound();
            }
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", infraction.TenantID);
            return View(infraction);
        }

        // POST: Infractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InfractionID,TenantID,Date,Reason,Amount,Paid")] Infraction infraction)
        {
            if (id != infraction.InfractionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfractionExists(infraction.InfractionID))
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
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", infraction.TenantID);
            return View(infraction);
        }

        // GET: Infractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infraction = await _context.Infractions
                .Include(i => i.Tenant)
                .FirstOrDefaultAsync(m => m.InfractionID == id);
            if (infraction == null)
            {
                return NotFound();
            }

            return View(infraction);
        }

        // POST: Infractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infraction = await _context.Infractions.FindAsync(id);
            _context.Infractions.Remove(infraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfractionExists(int id)
        {
            return _context.Infractions.Any(e => e.InfractionID == id);
        }
    }
}
