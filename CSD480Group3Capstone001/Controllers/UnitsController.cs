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
        public async Task<IActionResult> Create([Bind("UnitID,BuildingID,UnitNumber,SqrFootage")]
            Unit unit)
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
        public async Task<IActionResult> Edit(int id, [Bind("UnitID,BuildingID,UnitNumber,SqrFootage")]
            Unit unit)
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


        private static readonly List<string> SearchAreas = new List<string>()
        {
            "Tenant Name", "License Plate", "Unit", "Building Address"
        }; //this is where you put more option for the drop down

        // GET: Tenants/Search
        public IActionResult Search()
        {
            return View(GetFullUnits(_context.Units.ToList()));
        }

        // POST: Tenants/Search
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string searchString, string searchBy, string VacantUnitsOnly)
        {
            List<Unit> units = _context.Units.ToList();
            if (VacantUnitsOnly != null)
            {
                var unitIds = _context.TenantUnits.Where(rh => DateTime.Compare(rh.MovedOutDate,DateTime.Now) > 0).Select(u=>u.UnitID);
                units = units.Where(c => !unitIds.Contains(c.UnitID)).ToList();
                ViewData["VacantUnitsOnly"] = true;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["searchString"] = searchString;
            }

            if (!String.IsNullOrEmpty(searchBy))
            {
                ViewData["searchBy"] = searchBy;
            }


            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchBy) && units.Count() > 0)
            {

                searchString = searchString.ToLower();
                switch (searchBy)
                {
                    case "Tenant Name":
                        //get tenant ids of tenants whose names match the search query
                        var tenantIds = _context.Tenants.Where(t =>
                                t.FirstName.ToLower().Contains(searchString) ||
                                t.LastName.ToLower().Contains(searchString) ||
                                (t.FirstName.ToLower() + " " + t.LastName.ToLower()).Contains(searchString))
                            .Select(t => t.TenantID).ToList();
                        //get all the unitIds where tenantIds are present
                        var unitIds = _context.TenantUnits.Where(tu => tenantIds.Contains(tu.TenantID) && DateTime.Compare(tu.MovedOutDate, DateTime.Now) > 0)
                            .Select(tu => tu.UnitID).ToList();
                        units = units.Where(u => unitIds.Contains(u.UnitID)).ToList();
                        break;
                    case "License Plate":
                        //get all the tenanatIds that are associated with a vehicle license plate that matches the search string
                        tenantIds = _context.Vehicles.Where(v => v.LicensePlate.ToLower().Contains(searchString))
                            .Select(v => v.TenantID).ToList();
                        //get all the unitIds where tenantIds are present
                        unitIds = _context.TenantUnits.Where(tu => tenantIds.Contains(tu.TenantID) && DateTime.Compare(tu.MovedOutDate, DateTime.Now) > 0)
                            .Select(tu => tu.UnitID).ToList();
                        //because we are selecting from the units variable which has been filled with full tenants we will have access to vehicles, build etc in the views.
                        units = units.Where(u => unitIds.Contains(u.UnitID)).ToList();
                        break;
                    case "Unit":
                        units = units.Where(u => u.UnitNumber.ToLower().Contains(searchString)).ToList();
                        break;
                    case "Building Address":
                        var buildingIds = _context.Buildings.Where(tu => tu.Address.ToLower().Contains(searchString))
                            .Select(tu => tu.BuildingID).ToList();
                        //because we are selecting from the units variable which has been filled with full tenants we will have access to vehicles, build etc in the views.
                        units = units.Where(u => buildingIds.Contains(u.BuildingID)).ToList();
                        break;
                    //TODO: add more search cases and queries, make sure to add the case string to the searchAreas list
                    default:
                        // code block
                        break;
                }

            }

            return View(GetFullUnits(units));
        }

        public List<Unit> GetFullUnits(List<Unit> units)
        {
            List<Unit> tempUnits = new List<Unit>();
            foreach (Unit u in units)
            {
                tempUnits.Add(GetFullUnit(u));
            }

            return tempUnits;
        }

        public Unit GetFullUnit(Unit unit)
        {
            unit.Building = _context.Buildings.First(b => b.BuildingID.Equals(unit.BuildingID));
            unit.RepairHistories = _context.RepairHistories.Where(r => r.UnitID.Equals(unit.UnitID)).ToList();
            unit.TenantUnits = _context.TenantUnits.Where(t => t.UnitID.Equals(unit.UnitID)).ToList();
            foreach (TenantUnit tu in unit.TenantUnits)
            {
                tu.tenant = _context.Tenants.First(t => t.TenantID == tu.TenantID);
                tu.tenant.Vehicles = _context.Vehicles.Where(v => v.TenantID.Equals(tu.TenantID)).ToList();
            }

            return unit;
        }

        public static List<string> GetSearchAreas()
        {
            return new List<string>(SearchAreas);
        }

    }



}
