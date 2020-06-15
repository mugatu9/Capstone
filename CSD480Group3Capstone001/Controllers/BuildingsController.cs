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
    public class BuildingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuildingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Buildings.ToListAsync());
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.BuildingID == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildingID,Address,City,State,Zip,OrgName,TaxParcelYear,TaxParcelAmount")] Building building)
        {
            if (ModelState.IsValid)
            {
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildingID,Address,City,State,Zip,OrgName,TaxParcelYear,TaxParcelAmount")] Building building)
        {
            if (id != building.BuildingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.BuildingID))
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
            return View(building);
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.BuildingID == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.BuildingID == id);
        }


        private static readonly List<string> SearchAreas = new List<string>() { "Tenant Name", "License Plate", "Building Address"};//this is where you put more option for the drop down

        // GET: Tenants/Search
        public IActionResult Search()
        {
            return View(GetFullBuildings(_context.Buildings.ToList()));
        }

        // POST: Tenants/Search
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string searchString, string searchBy)
        {
            List<Building> buildings = _context.Buildings.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["searchString"] = searchString;
            }
            if (!String.IsNullOrEmpty(searchBy))
            {
                ViewData["searchBy"] = searchBy;
            }


            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchBy) && buildings.Count() > 0)
            {

                searchString = searchString.ToLower();
                switch (searchBy)
                {
                    case "Tenant Name":
                        //get tenant ids of tenants whose names match the search query
                        var tenantIds = _context.Tenants.Where(t => t.FirstName.ToLower().Contains(searchString) || t.LastName.ToLower().Contains(searchString) || (t.FirstName.ToLower() + " " + t.LastName.ToLower()).Contains(searchString)).Select(t => t.TenantID).ToList();
                        //get all the unitIds where tenantIds are present
                        var unitIds = _context.TenantUnits.Where(tu => tenantIds.Contains(tu.TenantID) && DateTime.Compare(tu.MovedOutDate,DateTime.Now) > 0).Select(tu => tu.UnitID).ToList();
                        //Get the building ids
                        var buildingIds = _context.Units.Where(u => unitIds.Contains(u.UnitID)).Select(u => u.BuildingID).ToList();

                        buildings = buildings.Where(b => buildingIds.Contains(b.BuildingID)).ToList();
                        break;
                    case "License Plate":
                        //get all the tenanatIds that are associated with a vehicle license plate that matches the search string
                        tenantIds = _context.Vehicles.Where(v => v.LicensePlate.ToLower().Contains(searchString) ).Select(v => v.TenantID).ToList();
                        //get all the unitIds where tenantIds are present
                        unitIds = _context.TenantUnits.Where(tu => tenantIds.Contains(tu.TenantID) && DateTime.Compare(tu.MovedOutDate, DateTime.Now) > 0).Select(tu => tu.UnitID).ToList();
                        //because we are selecting from the units variable which has been filled with full tenants we will have access to vehicles, build etc in the views
                        buildingIds = _context.Units.Where(u => unitIds.Contains(u.UnitID)).Select(u => u.BuildingID).ToList();

                        buildings = buildings.Where(b => buildingIds.Contains(b.BuildingID)).ToList();
                        break;
                    case "Building Address":
                        buildings = buildings.Where(b => b.Address.ToLower().Contains(searchString)).ToList();
                        break;
                    //TODO: add more search cases and queries, make sure to add the case string to the searchAreas list
                    default:
                        // code block
                        break;
                }

            }
            return View( GetFullBuildings(buildings));
        }

        public List<Building> GetFullBuildings(List<Building> buildings)
        {
            List<Building> tempBuildings = new List<Building>();
            foreach (Building b in buildings)
            {
                tempBuildings.Add(GetFullBuilding(b));
            }

            return tempBuildings;
        }
        public Building GetFullBuilding(Building building)
        {
            building.Units = _context.Units.Where(u => u.BuildingID.Equals(building.BuildingID)).ToList();
            foreach (var unit in building.Units)
            {
                unit.RepairHistories = _context.RepairHistories.Where(r => r.UnitID.Equals(unit.UnitID)).ToList();
                unit.TenantUnits = _context.TenantUnits.Where(t => t.UnitID.Equals(unit.UnitID)).ToList();
                foreach (var tu in unit.TenantUnits)
                {
                    tu.tenant = _context.Tenants.First(t => t.TenantID.Equals(tu.TenantID));
                    tu.tenant.Vehicles = _context.Vehicles.Where(v => v.TenantID.Equals(tu.tenant.TenantID)).ToList();
                }
            }
            return building;
        }

        public static List<string> GetSearchAreas()
        {
            return new List<string>(SearchAreas);
        }
    }
}
