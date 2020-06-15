using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSD480Group3Capstone001.Data;
using CSD480Group3Capstone001.Models;
using Microsoft.AspNetCore.Authorization;

namespace CSD480Group3Capstone001.Controllers
{
    public class TenantUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TenantUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "admin")]
        // GET: TenantUnits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TenantUnits.Include(t => t.tenant).Include(t => t.unit);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "admin")]
        // GET: TenantUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantUnit = await _context.TenantUnits
                .Include(t => t.tenant)
                .Include(t => t.unit)
                .FirstOrDefaultAsync(m => m.TenantID == id);
            if (tenantUnit == null)
            {
                return NotFound();
            }

            return View(tenantUnit);
        }
        [Authorize(Roles = "admin")]
        // GET: TenantUnits/Create
        public IActionResult Create()
        {
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID");
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID");
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: TenantUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenantID,UnitID")] TenantUnit tenantUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenantUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", tenantUnit.TenantID);
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", tenantUnit.UnitID);
            return View(tenantUnit);
        }
        [Authorize(Roles = "admin")]
        // GET: TenantUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantUnit = await _context.TenantUnits.FindAsync(id);
            if (tenantUnit == null)
            {
                return NotFound();
            }
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", tenantUnit.TenantID);
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", tenantUnit.UnitID);
            return View(tenantUnit);
        }
        [Authorize(Roles = "admin")]
        // POST: TenantUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenantID,UnitID")] TenantUnit tenantUnit)
        {
            if (id != tenantUnit.TenantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenantUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantUnitExists(tenantUnit.TenantID))
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
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", tenantUnit.TenantID);
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", tenantUnit.UnitID);
            return View(tenantUnit);
        }
        [Authorize(Roles = "admin")]
        // GET: TenantUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantUnit = await _context.TenantUnits
                .Include(t => t.tenant)
                .Include(t => t.unit)
                .FirstOrDefaultAsync(m => m.TenantID == id);
            if (tenantUnit == null)
            {
                return NotFound();
            }

            return View(tenantUnit);
        }
        [Authorize(Roles = "admin")]
        // POST: TenantUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenantUnit = await _context.TenantUnits.FindAsync(id);
            _context.TenantUnits.Remove(tenantUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantUnitExists(int id)
        {
            return _context.TenantUnits.Any(e => e.TenantID == id);
        }
    }
}
