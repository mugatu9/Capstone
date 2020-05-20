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

        // GET: Tenants/Create
        public IActionResult Search()
        {
            return View(_context.Tenants.ToList());
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string searchString, string searchBy )
        {
            List<Tenant> tenants = _context.Tenants.ToList();

            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchBy) && tenants.Count() > 0)
            {
                ViewData["searchString"] = searchString;
                ViewData["searchBy"] = searchBy;
                searchString = searchString.ToLower();
                switch (searchBy)
                {
                    case "Name":
                        tenants = (_context.Tenants.Where(s => s.FirstName.ToLower().Contains(searchString) || s.LastName.ToLower().Contains(searchString) || (s.FirstName.ToLower() + " " + s.LastName.ToLower()).Contains(searchString))).ToList();
                        break;
                    case "Unit":
                        //TODO: implement search query
                        break;
                    case "Building":
                        //TODO: implement search query
                        break;
                    case "License Plate":
                    //TODO: implement search query
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
                  
                        //TODO: add more search cases and queries
                    default:
                        // code block
                        break;
                }
                
            }
            return View(tenants);
        }
    }
}
/* user story queries
7.
List<Contractor> usedContractors = (from C in _context.Contractors join
                                               R in _context.RepairHistories on C.ContractorID equals R.ContractorID
                                               select C).ToList();
8.

9.


*/
