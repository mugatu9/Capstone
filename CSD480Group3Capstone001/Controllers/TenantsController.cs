using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSD480Group3Capstone001.Data;
using CSD480Group3Capstone001.Models;
using System.Collections;

namespace CSD480Group3Capstone001.Controllers
{
    [Route("api/Tenants")]
    [ApiController]
    public class TenantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static ArrayList UserData = new ArrayList();

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

        [HttpGet("GetTenant/{id}")]

        public ActionResult<Tenant> GetTenant(int id)
        {
            Tenant tenant = _context.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return tenant;
        }
        

        [HttpGet("GetAllTenants")]
        

        public List<Tenant> GetTenant()
        {
            // Return all Users
            return _context.Tenants.ToList();
        }



        [HttpPost]
        public async Task<ActionResult<Tenant>> PostTenant(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

           
            return CreatedAtAction(nameof(GetTenant), new { id = tenant.TenantID }, tenant);
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
