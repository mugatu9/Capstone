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
using Microsoft.AspNetCore.Authorization;

namespace CSD480Group3Capstone001.Controllers
{
    [Authorize(Roles = "Admin")]
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

        private static readonly List<string> SearchAreas =  new List<string>() { "Name", "License Plate", "Unit", "Building", "Employer", "Delinquent Rent", "Test" };//this is where you put more option for the drop down

    // GET: Tenants/Search
    public IActionResult Search()
        {
            return View(GetFullTenants());
        }

        // POST: Tenants/Search
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string searchString, string searchBy )
        {
            List<Tenant> tenants = GetFullTenants();

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchBy) && tenants.Count() > 0)
            {
                ViewData["searchString"] = searchString;
                ViewData["searchBy"] = searchBy;
                searchString = searchString.ToLower();
                switch (searchBy)
                {
                    case "Name":
                        tenants = tenants.Where(t => t.FirstName.ToLower().Contains(searchString) || t.LastName.ToLower().Contains(searchString) || (t.FirstName.ToLower() + " " + t.LastName.ToLower()).Contains(searchString)).ToList();
                        break;
                    case "License Plate":
                        List<int> tenantIds = (_context.Vehicles.Where(v => v.LicensePlate.ToLower().Contains(searchString))).Select(v => v.TenantID).ToList();
                        tenants = tenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "Unit":
                        //TODO: implement search query
                        break;
                    case "Building":
                        //TODO: implement search query
                        break;
                    case "Delinquent Rent":
                        var goodTenants = from R in _context.RentPayments join
                                          T in _context.Tenants on R.TenantID equals T.TenantID
                                           where (R.Date > DateTime.Now.AddDays(-30))  //R.Date < DateTime.Now && 
                                          select T;
                        var allTenants = from T in _context.Tenants
                                         select T;
                        var badTenants = (allTenants.AsEnumerable().Except(goodTenants.AsEnumerable()));
                        tenants = (from T in badTenants
                                  select T).ToList();

                        break;
                    case "Test":
                        int unitId = 5; // this will be a parameter passed to this query through a function
                        var unitTenants = from U in _context.Units join
                                               Tu in _context.TenantUnits on U.UnitID equals Tu.UnitID join
                                               T in _context.Tenants on Tu.TenantID equals T.TenantID
                                               where U.UnitID == unitId
                                               select T;
                        Tenant mostRecentTenant = unitTenants.OrderByDescending(m => m.MovedInDate).FirstOrDefault();
                     
                        tenants.Clear();
                        tenants.Add(mostRecentTenant);

                        break;
                        //TODO: add more search cases and queries
                    case "Employer":
                        tenants = tenants.Where(t => t.Employer.ToLower().Contains(searchString)).ToList();
                        break;
                    //TODO: add more search cases and queries, make sure to add the case string to the searchAreas list
                    default:
                        // code block
                        break;
                }
                
            }
            return View(tenants);
        }

        public List<Tenant> GetFullTenants()
        {
            List<Tenant> tempTenants = new List<Tenant>();
            foreach (Tenant t in _context.Tenants)
            {
                tempTenants.Add(GetFullTenant(t));
            }

            return tempTenants;
        }
        public Tenant GetFullTenant(Tenant tenant)
        {
            Tenant t = new Tenant
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                TenantID = tenant.TenantID,
                Employer = tenant.Employer,
                Salary = tenant.Salary,
                MovedInDate = tenant.MovedInDate,
                MovedOutDate = tenant.MovedOutDate,
                Infractions = _context.Infractions.Where(i => i.TenantID.Equals(tenant.TenantID)).ToList(),
                Vehicles = _context.Vehicles.Where(v => v.TenantID.Equals(tenant.TenantID)).ToList(),
                RentPayments = _context.RentPayments.Where(r => r.TenantID.Equals(tenant.TenantID)).ToList(),
                TenantUnits = _context.TenantUnits.Where(t => t.TenantID.Equals(tenant.TenantID)).ToList()
            };
            return t;
        }

        public static List<string> GetSearchAreas()
        {
            return new List<string>(SearchAreas);
        }

    }
}
/* user story queries
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
