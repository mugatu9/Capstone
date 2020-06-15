using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CSD480Group3Capstone001.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSD480Group3Capstone001.Models;
using CSD480Group3Capstone001.Views.Overview;

namespace CSD480Group3Capstone001.Controllers
{
    public class OverviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OverviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(GetOverViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private OverViewModel GetOverViewModel()
        {
            OverViewModel ov = new OverViewModel();
            ov.RentPayments = _context.RentPayments.ToList();
            ov.Infractions = _context.Infractions.ToList();
            ov.Buildings = _context.Buildings.ToList();
            return ov;
        }
    }
}
