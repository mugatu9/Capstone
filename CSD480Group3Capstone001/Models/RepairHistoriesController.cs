using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSD480Group3Capstone001.Data;

namespace CSD480Group3Capstone001.Models
{
    public class RepairHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepairHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepairHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RepairHistories.Include(r => r.Contractor).Include(r => r.Unit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RepairHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairHistory = await _context.RepairHistories
                .Include(r => r.Contractor)
                .Include(r => r.Unit)
                .FirstOrDefaultAsync(m => m.ContractorID == id);
            if (repairHistory == null)
            {
                return NotFound();
            }

            return View(repairHistory);
        }

        // GET: RepairHistories/Create
        public IActionResult Create()
        {
            ViewData["ContractorID"] = new SelectList(_context.Contractors, "ContractorID", "ContractorID");
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID");
            return View();
        }

        // POST: RepairHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractorID,UnitID,StartDate,FinishDate,Notes,Cost,Paid")] RepairHistory repairHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractorID"] = new SelectList(_context.Contractors, "ContractorID", "ContractorID", repairHistory.ContractorID);
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", repairHistory.UnitID);
            return View(repairHistory);
        }

        // GET: RepairHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairHistory = await _context.RepairHistories.FindAsync(id);
            if (repairHistory == null)
            {
                return NotFound();
            }
            ViewData["ContractorID"] = new SelectList(_context.Contractors, "ContractorID", "ContractorID", repairHistory.ContractorID);
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", repairHistory.UnitID);
            return View(repairHistory);
        }

        // POST: RepairHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractorID,UnitID,StartDate,FinishDate,Notes,Cost,Paid")] RepairHistory repairHistory)
        {
            if (id != repairHistory.ContractorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairHistoryExists(repairHistory.ContractorID))
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
            ViewData["ContractorID"] = new SelectList(_context.Contractors, "ContractorID", "ContractorID", repairHistory.ContractorID);
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", repairHistory.UnitID);
            return View(repairHistory);
        }

        // GET: RepairHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairHistory = await _context.RepairHistories
                .Include(r => r.Contractor)
                .Include(r => r.Unit)
                .FirstOrDefaultAsync(m => m.ContractorID == id);
            if (repairHistory == null)
            {
                return NotFound();
            }

            return View(repairHistory);
        }

        // POST: RepairHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairHistory = await _context.RepairHistories.FindAsync(id);
            _context.RepairHistories.Remove(repairHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairHistoryExists(int id)
        {
            return _context.RepairHistories.Any(e => e.ContractorID == id);
        }
    }
}
