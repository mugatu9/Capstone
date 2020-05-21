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
    public class UnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Units.Include(u => u.Building);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.Building)
                .FirstOrDefaultAsync(m => m.UnitID == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Units/Create
        public IActionResult Create()
        {
            ViewData["BuildingID"] = new SelectList(_context.Buildings, "BuildingID", "BuildingID");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitID,BuildingID,UnitNumber,SqrFootage")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingID"] = new SelectList(_context.Buildings, "BuildingID", "BuildingID", unit.BuildingID);
            return View(unit);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            ViewData["BuildingID"] = new SelectList(_context.Buildings, "BuildingID", "BuildingID", unit.BuildingID);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitID,BuildingID,UnitNumber,SqrFootage")] Unit unit)
        {
            if (id != unit.UnitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitExists(unit.UnitID))
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
            ViewData["BuildingID"] = new SelectList(_context.Buildings, "BuildingID", "BuildingID", unit.BuildingID);
            return View(unit);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.Building)
                .FirstOrDefaultAsync(m => m.UnitID == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.UnitID == id);
        }


        private static readonly List<string> SearchAreas = new List<string>() { "Name", "License Plate", "Unit", "Building", "Employer" };//this is where you put more option for the drop down

        // GET: Tenants/Search
        public IActionResult Search()
        {
            return View(GetFullUnits());
        }

        // POST: Tenants/Search
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string searchString, string searchBy)
        {
            List<Unit> dyUnits = GetFullUnits();

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchBy) && dyUnits.Count() > 0)
            {
                ViewData["searchString"] = searchString;
                ViewData["searchBy"] = searchBy;
                searchString = searchString.ToLower();
                switch (searchBy)
                {
                    case "Name":
                        //TODO: implement search query
                        break;
                    case "License Plate":
                        //TODO: implement search query
                        break;
                    case "Unit":
                        //TODO: implement search query
                        break;
                    case "Building":
                        //TODO: implement search query
                        break;
                    case "Employer":
                        //TODO: implement search query
                        break;
                    //TODO: add more search cases and queries, make sure to add the case string to the searchAreas list
                    default:
                        // code block
                        break;
                }

            }
            return View(dyUnits);
        }

        public List<Unit> GetFullUnits()
        {
            List<Unit> tempUnits = new List<Unit>();
            foreach (Unit u in _context.Units)
            {
                tempUnits.Add(GetFullUnit(u));
            }

            return tempUnits;
        }
        public Unit GetFullUnit(Unit unit)
        {
            Unit u = new Unit
            {
                UnitID = unit.UnitID,
                BuildingID = unit.BuildingID,
                UnitNumber = unit.UnitNumber,
                SqrFootage = unit.SqrFootage,
                Building   = _context.Buildings.Where(b=>b.BuildingID.Equals(unit.BuildingID)).ToList()[0],
                RepairHistories = _context.RepairHistories.Where(r => r.UnitID.Equals(unit.UnitID)).ToList(),
                TenantUnits = _context.TenantUnits.Where(t => t.UnitID.Equals(unit.UnitID)).ToList()
            };
            foreach (TenantUnit tu in u.TenantUnits)
            {
                tu.tenant = _context.Tenants.Where(t => t.TenantID == tu.TenantID).ToList()[0];
            }
            return u;
        }

        public static List<string> GetSearchAreas()
        {
            return new List<string>(SearchAreas);
        }

		
		
		
		
		
		
		
		//Query to get REPAIR HISTORY of a unit::
        public async Task<IActionResult> ViewRepairHistory(int? id)
        {
            if (id == null) return NotFound();
         
            var repHist = await _context.RepairHistories.FindAsync(id);
            await _context.RepairHistories
                .Include(r => r.Unit.RepairHistories)
                .FirstOrDefaultAsync(r => r.UnitID == id);

            if (repHist == null) return NotFound();
            
            return View(repHist);
        }




        //Get the TAX INFORMATION of a unit::
        public async Task<IActionResult> TaxInfo(int? id)
        {
            if (id == null) return NotFound();


            var tax = await _context.Buildings
                .Include(t => t.TaxParcelAmount)
                .Include(y => y.TaxParcelYear)
                .FirstOrDefaultAsync(t => t.BuildingID == id);
		        return(tax);
		    }
    }
}
