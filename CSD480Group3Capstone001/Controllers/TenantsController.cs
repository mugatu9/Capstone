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

        private static readonly List<string> SearchAreas =  new List<string>() { "Name", "License Plate", "Unit", "Building", "Employer" };//this is where you put more option for the drop down

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
            List<Tenant> dyTenants = GetFullTenants();

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchBy) && dyTenants.Count() > 0)
            {
                ViewData["searchString"] = searchString;
                ViewData["searchBy"] = searchBy;
                searchString = searchString.ToLower();
                switch (searchBy)
                {
                    case "Name":
                        dyTenants = dyTenants.Where(t => t.FirstName.ToLower().Contains(searchString) || t.LastName.ToLower().Contains(searchString) || (t.FirstName.ToLower() + " " + t.LastName.ToLower()).Contains(searchString)).ToList();
                        break;
                    case "License Plate":
                        List<int> tenantIds = (_context.Vehicles.Where(v => v.LicensePlate.ToLower().Contains(searchString))).Select(v => v.TenantID).ToList();
                        dyTenants = dyTenants.Where(t => tenantIds.Contains(t.TenantID)).ToList();
                        break;
                    case "Unit":
                        //TODO: implement search query
                        break;
                    case "Building":
                        //TODO: implement search query
                        break;
                    case "Employer":
                        dyTenants = dyTenants.Where(t => t.Employer.ToLower().Contains(searchString)).ToList();
                        break;
                    //TODO: add more search cases and queries, make sure to add the case string to the searchAreas list
                    default:
                        // code block
                        break;
                }
                
            }
            return View(dyTenants);
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
