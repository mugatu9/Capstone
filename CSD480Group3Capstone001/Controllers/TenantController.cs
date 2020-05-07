using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD480Group3Capstone001.Models;
using CSD480Group3Capstone001.Views.Tenant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSD480Group3Capstone001.Controllers
{
    [Authorize]
    public class TenantController : Controller
    {

        public IActionResult Index()
        {
            List<Tenant> tenants = new List<Tenant>();

            Tenant bob = new Tenant();
            bob.Employer = "Self Employed";
            bob.FirstName = "Bob";
            bob.LastName = "Belcher";
            bob.MovedInDate = DateTime.Today;
            bob.MovedOutDate = DateTime.Today;
            bob.Salary = 30000;
            bob.TenantID = 1;

            Tenant linn = new Tenant();
            linn.Employer = "Self Employed";
            linn.FirstName = "Linda";
            linn.LastName = "Belcher";
            linn.MovedInDate = DateTime.Today;
            linn.MovedOutDate = DateTime.Today;
            linn.Salary = 30000;
            linn.TenantID = 2;

            Tenant tina = new Tenant();
            tina.Employer = "Self Employed";
            tina.FirstName = "Tina";
            tina.LastName = "Belcher";
            tina.MovedInDate = DateTime.Today;
            tina.MovedOutDate = DateTime.Today;
            tina.Salary = 0;
            tina.TenantID = 3;

            tenants.Add(bob);
            tenants.Add(linn);
            tenants.Add(tina);
            tenants.Add(bob);
            tenants.Add(linn);
            tenants.Add(tina);
            tenants.Add(bob);
            tenants.Add(linn);
            tenants.Add(tina);
            tenants.Add(bob);
            tenants.Add(linn);
            tenants.Add(tina);

            return View(tenants);
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {


            List<Tenant> tenants = new List<Tenant>();

            Tenant bob = new Tenant();
            bob.Employer = "Self Employed";
            bob.FirstName = "Bob";
            bob.LastName = "Belcher";
            bob.MovedInDate = DateTime.Today;
            bob.MovedOutDate = DateTime.Today;
            bob.Salary = 30000;
            bob.TenantID = 1;

            Tenant linn = new Tenant();
            linn.Employer = "Self Employed";
            linn.FirstName = "Linda";
            linn.LastName = "Belcher";
            linn.MovedInDate = DateTime.Today;
            linn.MovedOutDate = DateTime.Today;
            linn.Salary = 30000;
            linn.TenantID = 2;

            Tenant tina = new Tenant();
            tina.Employer = "Self Employed";
            tina.FirstName = "Tina";
            tina.LastName = "Belcher";
            tina.MovedInDate = DateTime.Today;
            tina.MovedOutDate = DateTime.Today;
            tina.Salary = 0;
            tina.TenantID = 3;



            tenants.Add(bob);
            tenants.Add(linn);
            tenants.Add(tina);
            tenants.Add(bob);
            tenants.Add(linn);
            tenants.Add(tina);
            tenants.Add(bob);
            tenants.Add(linn);
            tenants.Add(tina);
            tenants.Add(bob);
            tenants.Add(linn);



            var Tenants = from t in tenants
                select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                Tenants = Tenants.Where(s => s.FirstName.ToLower().Contains(searchString) || s.LastName.ToLower().Contains(searchString) || (s.FirstName.ToLower()+" "+s.LastName.ToLower()).Contains(searchString));
            }
            return View(Tenants.ToList());
        }
    }
}