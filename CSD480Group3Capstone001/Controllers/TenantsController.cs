using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSD480Group3Capstone001.Data;
using CSD480Group3Capstone001.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSD480Group3Capstone001.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TenantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenants.ToListAsync());
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(m => m.TenantID == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // GET: Tenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenantID,FirstName,LastName,Employer,Salary,MovedInDate,MovedOutDate")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenantID,FirstName,LastName,Employer,Salary,MovedInDate,MovedOutDate")] Tenant tenant)
        {
            if (id != tenant.TenantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.TenantID))
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
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(m => m.TenantID == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantExists(int id)
        {
            return _context.Tenants.Any(e => e.TenantID == id);
        }

        private static readonly List<string> SearchAreas =  new List<string>() { "Name", "License Plate", "Unit#", "Street Address","City","State","Zip Code", "Employment" };//this is where you put more option for the drop down

    // GET: Tenants/Search
    public IActionResult Search()
        {
            return View(GetFullTenants(_context.Tenants.ToList()));
        }

        // POST: Tenants/Search
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string searchString, string searchBy, string lateRentOnly, string UnpaidFines)
        {
            List<Tenant> tenants = _context.Tenants.ToList();
            if (lateRentOnly != null)
            {
                var stillLiveHere = _context.TenantUnits.Where(rh => DateTime.Compare(rh.MovedOutDate, DateTime.Now) > 0).Select(u => u.TenantID);
                var firstOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var paidRent = _context.RentPayments.Where(rp=>DateTime.Compare(rp.Date, firstOfMonth) >= 0).Select(u => u.TenantID);
                tenants = tenants.Where(c => stillLiveHere.Contains(c.TenantID) && !paidRent.Contains(c.TenantID)).ToList();
                ViewData["lateRentOnly"] = true;
            }
            if (UnpaidFines != null)
            {
                var tenantIds = _context.Infractions.Where(i => !i.Paid).Select(i => i.TenantID);
                tenants = tenants.Where(c => tenantIds.Contains(c.TenantID)).ToList();
                ViewData["UnpaidFines"] = true;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["searchString"] = searchString;
            }
            if (!String.IsNullOrEmpty(searchBy))
            {
                ViewData["searchBy"] = searchBy;
            }    

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchBy) && tenants.Count() > 0)
            {
                searchString = searchString.ToLower();
                switch (searchBy)
                {
                    case "Name":
                        tenants = tenants.Where(t => t.FirstName.ToLower().Contains(searchString) || t.LastName.ToLower().Contains(searchString) || (t.FirstName.ToLower() + " " + t.LastName.ToLower()).Contains(searchString)).ToList();
                        break;
                    case "License Plate":
                        //get all the tenanatIds that are associated with a vehicle license plate that matches the search string
                        var tenantIds = _context.Vehicles.Where(v => v.LicensePlate.ToLower().Contains(searchString)).Select(v => v.TenantID).ToList();
                        //get only the tenants that have tenant ids in the ids from above
                        //because we are selecting from the tenants variable which has been filled with full tenants we will have access to vehicles, build etc in the views.
                        tenants = tenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "Unit#":
                        //get all the units with a unit number that match the search string
                        var unitIds = _context.Units.Where(u => u.UnitNumber.ToLower().Contains(searchString)).Select(u=>u.UnitID).ToList();
                        //get all the tenant ids that live in those units
                        tenantIds = _context.TenantUnits.Where(tu => unitIds.Contains(tu.UnitID)).Select(tu => tu.TenantID).ToList();
                        //get only the tenants that have tenant ids in the ids from above
                        tenants = tenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "Street Address":
                        //gets a list of building ids where the buildings address matches the search string
                        var buildingIds = _context.Buildings.Where(b => b.Address.ToLower().Contains(searchString)).Select(b => b.BuildingID).ToList();
                        //gets a list of unit ids for a building
                        unitIds = _context.Units.Where(u => buildingIds.Contains(u.BuildingID)).Select(u => u.UnitID).ToList();
                        //get a list of tenant ids who live in the units
                        tenantIds = _context.TenantUnits.Where(tu => unitIds.Contains(tu.UnitID)).Select(tu => tu.TenantID).ToList();
                        //get only the tenants that have tenant ids in the ids from above
                        tenants = tenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "City":
                        //gets a list of building ids where the buildings city matches the search string
                        buildingIds = _context.Buildings.Where(b => b.City.ToLower().Contains(searchString)).Select(b => b.BuildingID).ToList();
                        //gets a list of unit ids for a building
                        unitIds = _context.Units.Where(u => buildingIds.Contains(u.BuildingID)).Select(u => u.UnitID).ToList();
                        //get a list of tenant ids who live in the units
                        tenantIds = _context.TenantUnits.Where(tu => unitIds.Contains(tu.UnitID)).Select(tu => tu.TenantID).ToList();
                        //get only the tenants that have tenant ids in the ids from above
                        tenants = tenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "State":
                        //gets a list of building ids where the buildings State matches the search string
                        buildingIds = _context.Buildings.Where(b => b.State.ToLower().Contains(searchString)).Select(b => b.BuildingID).ToList();
                        //gets a list of unit ids for a building
                        unitIds = _context.Units.Where(u => buildingIds.Contains(u.BuildingID)).Select(u => u.UnitID).ToList();
                        //get a list of tenant ids who live in the units
                        tenantIds = _context.TenantUnits.Where(tu => unitIds.Contains(tu.UnitID)).Select(tu => tu.TenantID).ToList();
                        //get only the tenants that have tenant ids in the ids from above
                        tenants = tenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "Zip Code":
                        //gets a list of building ids where the buildings zip code matches the search string
                        buildingIds = _context.Buildings.Where(b => b.Zip.ToString().Contains(searchString)).Select(b => b.BuildingID).ToList();
                        //gets a list of unit ids for a building
                        unitIds = _context.Units.Where(u => buildingIds.Contains(u.BuildingID)).Select(u => u.UnitID).ToList();
                        //get a list of tenant ids who live in the units
                        tenantIds = _context.TenantUnits.Where(tu => unitIds.Contains(tu.UnitID)).Select(tu => tu.TenantID).ToList();
                        //get only the tenants that have tenant ids in the ids from above
                        tenants = tenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "Employment":
                        tenants = tenants.Where(t => t.Employment.ToLower().Contains(searchString)).ToList();
                        break;
                    //TODO: add more search cases and queries, make sure to add the case string to the searchAreas list
                    default:
                        // code block
                        break;
                }
                
            }


            return View(GetFullTenants(tenants));
        }

        public List<Tenant> GetFullTenants(List<Tenant> tenants)
        {
            List<Tenant> tempTenants = new List<Tenant>();
            foreach (Tenant t in tenants)
            {
                tempTenants.Add(GetFullTenant(t));
            }

            return tempTenants;
        }
        public Tenant GetFullTenant(Tenant tenant)
        {
            tenant.Infractions = _context.Infractions.Where(i => i.TenantID.Equals(tenant.TenantID)).ToList();
            tenant.Vehicles = _context.Vehicles.Where(v => v.TenantID.Equals(tenant.TenantID)).ToList();
            tenant.RentPayments = _context.RentPayments.Where(r => r.TenantID.Equals(tenant.TenantID)).ToList();
            tenant.TenantUnits = _context.TenantUnits.Where(t => t.TenantID.Equals(tenant.TenantID)).ToList();

            foreach (var tu in tenant.TenantUnits)
            {
                tu.unit = _context.Units.First(u => u.UnitID.Equals(tu.UnitID));
                tu.unit.Building = _context.Buildings.First(b => b.BuildingID.Equals(tu.unit.BuildingID));
            }
            return tenant;
        }

        public static List<string> GetSearchAreas()
        {
            return new List<string>(SearchAreas);
        }

    }
}
/* user story queries
1.
var tenantInfo = (from B in _context.Buildings join
                                         U in _context.Units on B.BuildingID equals U.BuildingID join
                                         TU in _context.TenantUnits on U.UnitID equals TU.UnitID join
                                         T in _context.Tenants on TU.TenantID equals T.TenantID join
                                         V in _context.Vehicles on T.TenantID equals V.TenantID
                                         where V.LicensePlate.Contains(searchString)
                                         select new { 
                                            building = B.Address,
                                            unit = U.UnitNumber,
                                            tenant = T.FirstName + " " + T.LastName,
                                            plate = V.LicensePlate
                                         }).ToList();
6.
var goodTenants = from R in _context.RentPayments join
                                          T in _context.Tenants on R.TenantID equals T.TenantID
                                           where (R.Date > DateTime.Now.AddDays(-30))  //R.Date < DateTime.Now && 
                                          select T;
                        var allTenants = from T in _context.Tenants
                                         select T;
                        var badTenants = (allTenants.AsEnumerable().Except(goodTenants.AsEnumerable()));
                        dyTenants = (from T in badTenants
                                  select T).ToList();

7.
List<Contractor> usedContractors = (from C in _context.Contractors join
                                               R in _context.RepairHistories on C.ContractorID equals R.ContractorID
                                               select C).ToList();
8.
var openWorkOrders = (from B in _context.Buildings join 
                                              U in _context.Units on B.BuildingID equals U.BuildingID join
                                              R in _context.RepairHistories on U.UnitID equals R.UnitID join
                                              C in _context.Contractors on R.ContractorID equals C.ContractorID
                                              where R.FinishDate == null
                                              select new{
                                                 address = B.Address,
                                                 contractor = C.Company,
                                                 unit = U.UnitNumber,
                                                 startDate = R.StartDate,
                                                 notes = R.Notes,
                                                 cost = R.Cost,
                                                 paid = R.Paid
                                              }
                                              ).ToList();
9.

    int unitId = 5; // this will be a parameter passed to this query through a function
                        var unitTenants = from U in _context.Units join
                                               Tu in _context.TenantUnits on U.UnitID equals Tu.UnitID join
                                               T in _context.Tenants on Tu.TenantID equals T.TenantID
                                               where U.UnitID == unitId
                                               select T;
                        Tenant mostRecentTenant = unitTenants.OrderByDescending(m => m.MovedInDate).FirstOrDefault();
                     
                        tenants.Clear();
                        tenants.Add(mostRecentTenant);
*/
