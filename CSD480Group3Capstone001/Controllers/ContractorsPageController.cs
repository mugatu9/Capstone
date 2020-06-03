using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSD480Group3Capstone001.Models;
using CSD480Group3Capstone001.Data;
using CSD480Group3Capstone001.Views.ContractorsPage;

namespace CSD480Group3Capstone001.Controllers
{
    public class ContractorsPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractorsPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(GetContractorRepairHistory(_context.Contractors.ToList(), _context.RepairHistories.ToList()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        private static readonly List<string> SearchContractorAreas = new List<string>() { "Specialty", "Previously Used" };//this is where you put more option for the drop down

        private static readonly List<string> SearchWorkOrderAreas = new List<string>() { "Company" };//this is where you put more option for the drop down
  
        // POST: Tenants/Search
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string contractSearchString, string contractSearchBy, string repairSearchString, string repairSearchBy)
        {
            List<Contractor> contractors = _context.Contractors.ToList();


            if (!String.IsNullOrEmpty(contractSearchString))
            {
                ViewData["contractSearchString"] = contractSearchString;
            }
            if (!String.IsNullOrEmpty(contractSearchBy))
            {
                ViewData["contractSearchBy"] = contractSearchBy;
            }

            if (!String.IsNullOrEmpty(contractSearchString) && !String.IsNullOrEmpty(contractSearchBy) && contractors.Count() > 0)
            {
                contractSearchString = contractSearchString.ToLower();
                switch (contractSearchBy)
                {
                    case "Specialty":
                        //get contractors whos Specialty match the search query
                        contractors = contractors.Where(c => c.Specialty.ToLower().Contains(contractSearchString)).ToList();
                        break;
                    case "Previously Used":
                        contractors = (from C in _context.Contractors join
                                       R in _context.RepairHistories on C.ContractorID equals R.ContractorID
                                       select C).Distinct().ToList();
                        break;
                    default:
                        // code block
                        break;
                }

            }
            List<RepairHistory> repairs = _context.RepairHistories.ToList();

            if (!String.IsNullOrEmpty(repairSearchString))
            {
                ViewData["repairSearchString"] = repairSearchString;
            }
            if (!String.IsNullOrEmpty(repairSearchBy))
            {
                ViewData["repairSearchBy"] = repairSearchBy;
            }

            if (!String.IsNullOrEmpty(repairSearchString) && !String.IsNullOrEmpty(repairSearchBy) && contractors.Count() > 0)
            {
                repairSearchString = repairSearchString.ToLower();
                switch (repairSearchBy)
                {
                    case "Company":
                        var conIds = _context.Contractors.Where(c => c.Company.ToLower().Contains(repairSearchString)).Select(c=>c.ContractorID).ToList();
                        repairs = repairs.Where(r => conIds.Contains(r.ContractorID)).ToList();
                        break;
                    default:
                        // code block
                        break;
                }

            }
            return View(GetContractorRepairHistory(contractors,repairs));
        }




        private Contractor_RepairHistory GetContractorRepairHistory(List<Contractor> con, List<RepairHistory> rh)
        {
            Contractor_RepairHistory cr = new Contractor_RepairHistory();
            List<Contractor> tempCons = new List<Contractor>();
            foreach (var c in con)
            {
                tempCons.Add(c);
            }
            cr.Contractors = tempCons;

            List<RepairHistory> tempRepair = new List<RepairHistory>();
            foreach (var r in rh)
            {
                tempRepair.Add(GetFullRepairHistory(r));
            }
            cr.RepairHistory = tempRepair;
            return cr;
        }



        private RepairHistory GetFullRepairHistory(RepairHistory rh)
        {
            rh.Unit = _context.Units.First(u => u.UnitID.Equals(rh.UnitID));
            rh.Contractor = _context.Contractors.First(c => c.ContractorID.Equals(rh.ContractorID));
            return rh;
        }

       
        public static List<string> GetContractorSearchAreas()
        {
            return new List<string>(SearchContractorAreas);
        }

     
        public static List<string> GetRepairSearchAreas()
        {
            return new List<string>(SearchWorkOrderAreas);
        }
    }
}
