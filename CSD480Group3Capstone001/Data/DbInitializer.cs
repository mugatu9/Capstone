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
        public static void Initialize(ApplicationDbContext context) {
            context.Database.EnsureCreated();
            if (context.Buildings.Any()) {
                return; // database is already seeded
            }

           

            var buildings = new Building[]
            {
                new Building {Address = "503 7th Ave", City = "Kirkland", State = "WA", Zip = 66666, OrgName = "Amazon", TaxParcelYear = 1999, TaxParcelAmount = 666},
                new Building {Address = "417 4th Ave N", City = "Lynnwood", State = "WA", Zip = 18347, OrgName = "Microsoft", TaxParcelYear = 1969, TaxParcelAmount = 777},
                new Building {Address = "111 12th st", City = "Seattle", State = "WA", Zip = 54532, OrgName = "Google", TaxParcelYear = 1979, TaxParcelAmount = 888},
                new Building {Address = "222 55th Ave", City = "Spokane", State = "WA", Zip = 19328, OrgName = "LWtech", TaxParcelYear = 1989, TaxParcelAmount = 999},
                new Building {Address = "333 33rd Ave", City = "Edmonds", State = "WA", Zip = 10383, OrgName = "UW", TaxParcelYear = 1929, TaxParcelAmount = 111},
                new Building {Address = "444 77th st", City = "Yakima", State = "WA", Zip = 10109, OrgName = "Quadrant Homes", TaxParcelYear = 1995, TaxParcelAmount = 222},
                new Building {Address = "555 1st Ave", City = "Index", State = "WA", Zip = 23434, OrgName = "Wizards of the Coast", TaxParcelYear = 1992, TaxParcelAmount = 333},
                new Building {Address = "666 Route 66", City = "Snohomish", State = "WA", Zip = 03834, OrgName = "Hasbro", TaxParcelYear = 1991, TaxParcelAmount = 444},
                new Building {Address = "777 54th Ave W", City = "Everett", State = "WA", Zip = 06575, OrgName = "Youtube", TaxParcelYear = 1996, TaxParcelAmount = 555},
                new Building {Address = "888 44th Ave", City = "Ellensburg", State = "WA", Zip = 15273, OrgName = "Spotify", TaxParcelYear = 1997, TaxParcelAmount = 434}

            };

            foreach (Building b in buildings)
            {
                context.Buildings.Add(b);
            }
            context.SaveChanges();




            var units = new Unit[]
                        {
                            new Unit {BuildingID = buildings.Single(b => b.Address == "503 7th Ave").BuildingID, UnitNumber = "1A", SqrFootage = 5000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "417 4th Ave N").BuildingID, UnitNumber = "2A", SqrFootage = 6000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "111 12th st").BuildingID, UnitNumber = "3A", SqrFootage = 7000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "222 55th Ave").BuildingID, UnitNumber = "4A", SqrFootage = 8000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "333 33rd Ave").BuildingID, UnitNumber = "5A", SqrFootage = 9000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "444 77th st").BuildingID, UnitNumber = "6A", SqrFootage = 10000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "555 1st Ave").BuildingID, UnitNumber = "7A", SqrFootage = 1000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "666 Route 66").BuildingID, UnitNumber = "8A", SqrFootage = 2000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "777 54th Ave W").BuildingID, UnitNumber = "9A", SqrFootage = 3000},
                            new Unit {BuildingID = buildings.Single(b => b.Address == "888 44th Ave").BuildingID, UnitNumber = "1B", SqrFootage = 4000}

                        };

            foreach (Unit u in units)
            {
                context.Units.Add(u);
            }
            context.SaveChanges();



            var contractors = new Contractor[]
                        {
                            new Contractor {Company = "Beacon Plumbing", Specialty = "Plumbing"},
                            new Contractor {Company = "Lake East Landscape", Specialty = "Landscaping"},
                            new Contractor {Company = "Reliable Floor Coverings", Specialty = "Flooring"},
                            new Contractor {Company = "Molly Maid", Specialty = "Cleaning"},
                            new Contractor {Company = "Mark Construction inc", Specialty = "Construction"},
                            new Contractor {Company = "B&E Heating", Specialty = "Heating"},
                            new Contractor {Company = "Southwest Plumbing", Specialty = "Plumbing"},
                            new Contractor {Company = "Bradley Paint", Specialty = "Painting"},
                            new Contractor {Company = "Edmonds Landscaping", Specialty = "Landscaping"},
                            new Contractor {Company = "A&E Construction", Specialty = "Construction"},
                        };

            foreach (Contractor c in contractors)
            {
                context.Contractors.Add(c);
            }
            context.SaveChanges();



            var repairHistories = new RepairHistory[]
                        {
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Beacon Plumbing").ContractorID, UnitID = units.Single(u => u.UnitNumber == "1A").UnitID, StartDate = DateTime.Parse("2020-05-01"), FinishDate = DateTime.Parse("2020-05-01"), Notes ="", Cost = 1000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Lake East Landscape").ContractorID, UnitID = units.Single(u => u.UnitNumber == "2A").UnitID, StartDate = DateTime.Parse("2020-06-01"), FinishDate = DateTime.Parse("2020-06-01"), Notes ="", Cost = 2000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Reliable Floor Coverings").ContractorID, UnitID = units.Single(u => u.UnitNumber == "3A").UnitID, StartDate = DateTime.Parse("2020-07-01"), FinishDate = DateTime.Parse("2020-07-01"), Notes ="", Cost = 3000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Molly Maid").ContractorID, UnitID = units.Single(u => u.UnitNumber == "4A").UnitID, StartDate = DateTime.Parse("2020-08-01"), FinishDate = DateTime.Parse("2020-08-01"), Notes ="", Cost = 4000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Mark Construction inc").ContractorID, UnitID = units.Single(u => u.UnitNumber == "5A").UnitID, StartDate = DateTime.Parse("2020-09-01"), FinishDate = DateTime.Parse("2020-09-01"), Notes ="", Cost = 5000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "B&E Heating").ContractorID, UnitID = units.Single(u => u.UnitNumber == "6A").UnitID, StartDate = DateTime.Parse("2020-10-01"), FinishDate = DateTime.Parse("2020-10-01"), Notes ="", Cost = 6000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Southwest Plumbing").ContractorID, UnitID = units.Single(u => u.UnitNumber == "7A").UnitID, StartDate = DateTime.Parse("2020-11-01"), FinishDate = DateTime.Parse("2020-11-01"), Notes ="", Cost = 7000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Bradley Paint").ContractorID, UnitID = units.Single(u => u.UnitNumber == "8A").UnitID, StartDate = DateTime.Parse("2020-12-01"), FinishDate = DateTime.Parse("2020-12-01"), Notes ="", Cost = 8000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "Edmonds Landscaping").ContractorID, UnitID = units.Single(u => u.UnitNumber == "9A").UnitID, StartDate = DateTime.Parse("2020-01-01"), FinishDate = DateTime.Parse("2020-01-01"), Notes ="", Cost = 9000.22M, Paid = false },
                            new RepairHistory {ContractorID = contractors.Single(c => c.Company == "A&E Construction").ContractorID, UnitID = units.Single(u => u.UnitNumber == "1B").UnitID, StartDate = DateTime.Parse("2020-02-01"), FinishDate = DateTime.Parse("2020-02-01"), Notes ="", Cost = 10000.22M, Paid = false }


                        };

            foreach (RepairHistory r in repairHistories)
            {
                context.RepairHistories.Add(r);
            }
            context.SaveChanges();



            var tenants = new Tenant[]
                        {
                            new Tenant {FirstName = "Nathan", LastName = "O'Brien", Employer = "The Moon", Salary = 99999999M, MovedInDate = DateTime.Parse("2020-05-01"), MovedOutDate = DateTime.Parse("2020-05-01") },
                            new Tenant {FirstName = "Donald", LastName = "Duck", Employer = "Disney", Salary = 88999999M, MovedInDate = DateTime.Parse("2020-06-01"), MovedOutDate = DateTime.Parse("2020-06-01") },
                            new Tenant {FirstName = "Shrek", LastName = "Getoutmyswamp", Employer = "Swamp", Salary = 77799999M, MovedInDate = DateTime.Parse("2020-07-01"), MovedOutDate = DateTime.Parse("2020-07-01") },
                            new Tenant {FirstName = "Lord", LastName = "Farquad", Employer = "God", Salary = 6679999M, MovedInDate = DateTime.Parse("2020-08-01"), MovedOutDate = DateTime.Parse("2020-08-01") },
                            new Tenant {FirstName = "Don", LastName = "Corleone", Employer = "The Mob", Salary = 333339999M, MovedInDate = DateTime.Parse("2020-09-01"), MovedOutDate = DateTime.Parse("2020-09-01") },
                            new Tenant {FirstName = "Ryan", LastName = "Gosling", Employer = "Your Mother", Salary = 55559999M, MovedInDate = DateTime.Parse("2020-10-01"), MovedOutDate = DateTime.Parse("2020-10-01") },
                            new Tenant {FirstName = "Alice", LastName = "Cooper", Employer = "Rock", Salary = 4444999M, MovedInDate = DateTime.Parse("2020-11-01"), MovedOutDate = DateTime.Parse("2020-11-01") },
                            new Tenant {FirstName = "Donald", LastName = "Trump", Employer = "Cancer", Salary = 33399999M, MovedInDate = DateTime.Parse("2020-12-01"), MovedOutDate = DateTime.Parse("2020-12-01") },
                            new Tenant {FirstName = "Vincent", LastName = "Price", Employer = "Horror", Salary = 22229999M, MovedInDate = DateTime.Parse("2020-01-01"), MovedOutDate = DateTime.Parse("2020-01-01") },
                            new Tenant {FirstName = "Jeff", LastName = "Lebowski", Employer = "Everywhere", Salary = 11119999M, MovedInDate = DateTime.Parse("2020-02-01"), MovedOutDate = DateTime.Parse("2020-02-01") }




                        };

            foreach (Tenant t in tenants)
            {
                context.Tenants.Add(t);
            }
            context.SaveChanges();

            var tenantUnits = new TenantUnit[]
                        {
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, UnitID = units.Single(u => u.UnitNumber == "1A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, UnitID = units.Single(u => u.UnitNumber == "2A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Getoutmyswamp").TenantID, UnitID = units.Single(u => u.UnitNumber == "3A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, UnitID = units.Single(u => u.UnitNumber == "4A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, UnitID = units.Single(u => u.UnitNumber == "5A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, UnitID = units.Single(u => u.UnitNumber == "6A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, UnitID = units.Single(u => u.UnitNumber == "7A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, UnitID = units.Single(u => u.UnitNumber == "8A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, UnitID = units.Single(u => u.UnitNumber == "9A").UnitID},
                            new TenantUnit {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, UnitID = units.Single(u => u.UnitNumber == "1B").UnitID},


                        };

            foreach (TenantUnit t in tenantUnits)
            {
                context.TenantUnits.Add(t);
            }
            context.SaveChanges();



            var infractions = new Infraction[]
                        {
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, Date = DateTime.Parse("2020-05-01"), Reason = "Cause screw you", Amount = 1200M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-06-01"), Reason = "Cause screw you", Amount = 1300M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Getoutmyswamp").TenantID, Date = DateTime.Parse("2020-07-01"), Reason = "Cause screw you", Amount = 1400M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2020-08-01"), Reason = "Cause screw you", Amount = 1500M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2020-09-01"), Reason = "Cause screw you", Amount = 1600M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-10-01"), Reason = "Cause screw you", Amount = 1700M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-11-01"), Reason = "Cause screw you", Amount = 1800M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2020-12-01"), Reason = "Cause screw you", Amount = 1900M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2020-01-01"), Reason = "Cause screw you", Amount = 1100M, Paid = false},
                            new Infraction {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2020-02-01"), Reason = "Cause screw you", Amount = 2000M, Paid = false},


                        };

            foreach (Infraction i in infractions)
            {
                context.Infractions.Add(i);
            }
            context.SaveChanges();



            var rentPayments = new RentPayment[]
                        {
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, Date = DateTime.Parse("2020-05-01"), Amount = 1200M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-06-01"), Amount = 1300M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Getoutmyswamp").TenantID, Date = DateTime.Parse("2020-07-01"), Amount = 1400M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2020-08-01"), Amount = 1500M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2020-09-01"), Amount = 1600M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-10-01"), Amount = 1700M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-11-01"), Amount = 1800M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2020-12-01"), Amount = 1900M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2020-01-01"), Amount = 1100M},
                            new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2020-02-01"), Amount = 2000M}

                        };

            foreach (RentPayment r in rentPayments)
            {
                context.RentPayments.Add(r);
            }
            context.SaveChanges();


            
            var vehicles = new Vehicle[]
                        {
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, LicensePlate = "GETR3KT", Model = "Ferrari", Year = 2025, Color = "Purple"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, LicensePlate = "SUCKIT", Model = "Volvo", Year = 1999, Color = "Red"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Getoutmyswamp").TenantID, LicensePlate = "AMFTHER", Model = "Lincoln", Year = 1995, Color = "Greem"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, LicensePlate = "BESTCAR", Model = "Tesla", Year = 3000, Color = "Orange"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, LicensePlate = "USUCK", Model = "Mercury", Year = 2020, Color = "Blue"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, LicensePlate = "AMURGOD", Model = "Buick", Year = 1966, Color = "Black"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, LicensePlate = "MAKIK", Model = "Ford", Year = 2007, Color = "Silver"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, LicensePlate = "DONNY", Model = "Honda", Year = 2001, Color = "Grey"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, LicensePlate = "FASTER", Model = "Hyundai", Year = 2000, Color = "White"},
                            new Vehicle {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, LicensePlate = "WILRAGE", Model = "Porsche", Year = 1992, Color = "Yellow"},

                        };

            foreach (Vehicle v in vehicles)
            {
                context.Vehicles.Add(v);
            }
            context.SaveChanges();




        }
    }
}
