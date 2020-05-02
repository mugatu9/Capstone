using CSD480Group3Capstone001.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PropertyManagementContext context) {
            context.Database.EnsureCreated();
            if (context.Buildings.Any()) {
                return; // database is already seeded
            }

            var buildings = new Building[]
            {
                new Building {Address = "503 7th Ave", City = "Kirkland", State = "WA", Zip = 66666, OrgName = "Amazon"}

            };

            foreach (Building b in buildings)
            {
                context.Buildings.Add(b);
            }
            context.SaveChanges();



            var taxParcels = new TaxParcel[]
            {
                new TaxParcel {BuildingID = buildings.Single(b => b.Address == "503 7th Ave").BuildingID,Year = 1999, Amount = 666}

            };

            foreach (TaxParcel t in taxParcels)
            {
                context.TaxParcels.Add(t);
            }
            context.SaveChanges();



            var units = new Unit[]
                        {
                            new Unit {BuildingID = buildings.Single(b => b.Address == "503 7th Ave").BuildingID, UnitNumber = "1A", SqrFootage = 5000}

                        };

            foreach (Unit u in units)
            {
                context.Units.Add(u);
            }
            context.SaveChanges();



            var contractors = new Contractor[]
                        {
                            new Contractor {Company = "Beacon Plumbing", Specialty = "Plumbing"}
                        };

            foreach (Contractor c in contractors)
            {
                context.Contractors.Add(c);
            }
            context.SaveChanges();



            var repairHistories = new RepairHistory[]
                        {
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Beacon Plumbing").ContractorID, UnitID = units.Single(u => u.UnitNumber == "1A").UnitID, StartDate = DateTime.Parse("2020-05-01"), FinishDate = DateTime.Parse("2020-05-01"), Notes ="", Cost = 1000.22M, Paid = false }

                        };

            foreach (RepairHistory r in repairHistories)
            {
                context.RepairHistories.Add(r);
            }
            context.SaveChanges();





            var tenants = new Tenant[]
                        {
                            new Tenant {FirstName = "Nathan", LastName = "O'Brien", Employer = "The Moon", Salary = 99999999M, MovedInDate = DateTime.Parse("2020-05-01"), MovedOutDate = DateTime.Parse("2020-05-01")}


                        };

            foreach (Tenant t in tenants)
            {
                context.Tenants.Add(t);
            }
            context.SaveChanges();



            var infractions = new Infraction[]
                        {
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, Date = DateTime.Parse("2020-05-01"), Reason = "Cause screw you", Amount = 1200M, Paid = false}

                        };

            foreach (Infraction i in infractions)
            {
                context.Infractions.Add(i);
            }
            context.SaveChanges();



            var rentPayments = new RentPayment[]
                        {
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, UnitID = units.Single(u => u.UnitNumber == "1A").UnitID, Date = DateTime.Parse("2020-05-01"), Amount = 1200M}

                        };

            foreach (RentPayment r in rentPayments)
            {
                context.RentPayments.Add(r);
            }
            context.SaveChanges();




            
            var vehicles = new Vehicle[]
                        {
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, LicensePlate = "GETR3KT", Model = "Ferrari", Year = 2025, Color = "Purple"}

                        };

            foreach (Vehicle v in vehicles)
            {
                context.Vehicles.Add(v);
            }
            context.SaveChanges();




        }
    }
}
