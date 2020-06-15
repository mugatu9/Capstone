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
    public class RentPaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentPaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "admin")]
        // GET: RentPayments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentPayments.Include(r => r.tenant);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "admin")]
        // GET: RentPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentPayment = await _context.RentPayments
                .Include(r => r.tenant)
                .FirstOrDefaultAsync(m => m.RentPaymentID == id);
            if (rentPayment == null)
            {
                return NotFound();
            }

            return View(rentPayment);
        }
        [Authorize(Roles = "admin")]
        // GET: RentPayments/Create
        public IActionResult Create()
        {
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID");
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: RentPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentPaymentID,TenantID,Date,Amount")] RentPayment rentPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", rentPayment.TenantID);
            return View(rentPayment);
        }
        [Authorize(Roles = "admin")]
        // GET: RentPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentPayment = await _context.RentPayments.FindAsync(id);
            if (rentPayment == null)
            {
                return NotFound();
            }
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", rentPayment.TenantID);
            return View(rentPayment);
        }
        [Authorize(Roles = "admin")]
        // POST: RentPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentPaymentID,TenantID,Date,Amount")] RentPayment rentPayment)
        {
            if (id != rentPayment.RentPaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentPaymentExists(rentPayment.RentPaymentID))
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
            ViewData["TenantID"] = new SelectList(_context.Tenants, "TenantID", "TenantID", rentPayment.TenantID);
            return View(rentPayment);
        }
        [Authorize(Roles = "admin")]
        // GET: RentPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentPayment = await _context.RentPayments
                .Include(r => r.tenant)
                .FirstOrDefaultAsync(m => m.RentPaymentID == id);
            if (rentPayment == null)
            {
                return NotFound();
            }

            return View(rentPayment);
        }
        [Authorize(Roles = "admin")]
        // POST: RentPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentPayment = await _context.RentPayments.FindAsync(id);
            _context.RentPayments.Remove(rentPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentPaymentExists(int id)
        {
            return _context.RentPayments.Any(e => e.RentPaymentID == id);
        }
    }
}
