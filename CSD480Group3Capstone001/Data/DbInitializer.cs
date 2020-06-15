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
                ClearDb(context);
                //return;
            }

            var buildings = new Building[]
            {
                new Building {Address = "503 7th Ave", City = "Kirkland", State = "WA", Zip = 98033, OrgName = "Kirkland Property Group", TaxParcelNumber = 9517200430, AppraisedValue = 375000, PurchaseDate = DateTime.Parse("2017-05-01")},
                new Building {Address = "417 4th Ave N", City = "Lynnwood", State = "WA", Zip = 98072, OrgName = "Lynnwood Property Group", TaxParcelNumber = 1927300900, AppraisedValue = 150000,PurchaseDate = DateTime.Parse("2019-01-01")},
                new Building {Address = "111 12th st", City = "Seattle", State = "WA", Zip = 98032, OrgName = "Seattle Property Group", TaxParcelNumber = 9517300100,AppraisedValue = 412000,PurchaseDate = DateTime.Parse("2017-06-01")}
            };
            context.Buildings.AddRange(buildings);
            context.SaveChanges();
            var units = new Unit[]
                {
                    new Unit {BuildingID = buildings.Single(b => b.Address == "503 7th Ave").BuildingID, UnitNumber = "A", SqrFootage = 1000},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "503 7th Ave").BuildingID, UnitNumber = "B", SqrFootage = 1000},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "503 7th Ave").BuildingID, UnitNumber = "C", SqrFootage = 1500},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "503 7th Ave").BuildingID, UnitNumber = "D", SqrFootage = 1500},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "417 4th Ave N").BuildingID, UnitNumber = "1", SqrFootage = 2000},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "417 4th Ave N").BuildingID, UnitNumber = "2", SqrFootage = 2000},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "111 12th st").BuildingID, UnitNumber = "1A", SqrFootage = 900},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "111 12th st").BuildingID, UnitNumber = "1B", SqrFootage = 900},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "111 12th st").BuildingID, UnitNumber = "1C", SqrFootage = 900},
                    new Unit {BuildingID = buildings.Single(b => b.Address == "111 12th st").BuildingID, UnitNumber = "1D", SqrFootage = 900}

                };
            foreach (var u in units)
            {
                context.Units.Add(u);
            }
            //context.Units.AddRange(units);
            context.SaveChanges();
            var contractors = new Contractor[]
                {
                    new Contractor {Company = "Beacon Plumbing", Specialty = "Plumbing", PhoneNumber = "(206) 364-5205"},
                    new Contractor {Company = "Lake East Landscape", Specialty = "Landscaping", PhoneNumber = "(206) 825-1979"},
                    new Contractor {Company = "Reliable Floor Coverings", Specialty = "Flooring", PhoneNumber = "(206) 926-2370"},
                    new Contractor {Company = "Molly Maid", Specialty = "Cleaning", PhoneNumber = "(206) 344-8959"},
                    new Contractor {Company = "Mark Construction inc", Specialty = "Construction", PhoneNumber = "(206) 274-3152"},
                    new Contractor {Company = "B&E Heating", Specialty = "Heating", PhoneNumber = "(206) 776-5223"},
                    new Contractor {Company = "Southwest Plumbing", Specialty = "Plumbing", PhoneNumber = "(206) 243-1994"},
                    new Contractor {Company = "Bradley Paint", Specialty = "Painting", PhoneNumber = "(206) 331-6657"},
                    new Contractor {Company = "Edmonds Landscaping", Specialty = "Landscaping", PhoneNumber = "(206) 928-6138"},
                    new Contractor {Company = "A&E Construction", Specialty = "Construction", PhoneNumber = "(206) 817-4522"},
                };
            context.Contractors.AddRange(contractors);
            context.SaveChanges();
            var repairHistories = new RepairHistory[]
                {
                    //This Year Completed Paid
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Beacon Plumbing").ContractorID, 
                        BuidlingID = buildings.Single(b=>b.Address.Equals("503 7th Ave")).BuildingID,
                        UnitID = units.Single(u => u.UnitNumber == "A").UnitID,
                        StartDate = DateTime.Parse("2020-05-01"),
                        FinishDate = DateTime.Parse("2020-05-01"),
                        Notes ="Fixed a burst pipe in master bathroom", Cost = 500,
                        Paid = true
                    },
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "B&E Heating").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("503 7th Ave")).BuildingID,
                        UnitID = units.Single(u => u.UnitNumber == "B").UnitID,
                        StartDate = DateTime.Parse("2020-03-01"),
                        FinishDate = DateTime.Parse("2020-03-06"),
                        Notes ="Replaced a heater unit",
                        Cost = 6000,
                        Paid = true
                    },
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Southwest Plumbing").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("417 4th Ave N")).BuildingID,
                        UnitID = units.Single(u => u.UnitNumber == "1").UnitID,
                        StartDate = DateTime.Parse("2020-04-01"),
                        FinishDate = DateTime.Parse("2020-04-01"),
                        Notes ="Replaced broken toilet",
                        Cost = 1000,
                        Paid = true
                    },
                    
                    //This Year Completed UnPaid
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Molly Maid").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("417 4th Ave N")).BuildingID,
                        UnitID = units.Single(u => u.UnitNumber == "2").UnitID,
                        StartDate = DateTime.Parse("2020-06-09"),
                        FinishDate = DateTime.Parse("2020-06-10"),
                        Notes ="Move out cleaning service",
                        Cost = 400,
                        Paid = false
                    },
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Lake East Landscape").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("111 12th st")).BuildingID,
                        UnitID = null,
                        StartDate = DateTime.Parse("2020-06-01"),
                        FinishDate = DateTime.Parse("2020-06-10"),
                        Notes ="Updated landscaping with a more modern look",
                        Cost = 5200,
                        Paid = false
                    },
                    //This Year in Progress
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Mark Construction inc").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("503 7th Ave")).BuildingID,
                        UnitID = null,
                        StartDate = DateTime.Parse("2020-01-01"),
                        FinishDate = null,
                        Notes ="Building a on site gym",
                        Cost = 500000,
                        Paid = false
                    },
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Reliable Floor Coverings").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("111 12th st")).BuildingID,
                        UnitID = units.Single(u => u.UnitNumber == "1C").UnitID,
                        StartDate = DateTime.Parse("2020-06-01"),
                        FinishDate = null, Notes ="Recovering floors",
                        Cost = 3500,
                        Paid = false
                    },
                    //Last Year Completed
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Bradley Paint").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("111 12th st")).BuildingID,
                        UnitID = units.Single(u => u.UnitNumber == "1D").UnitID,
                        StartDate = DateTime.Parse("2019-12-01"), FinishDate = DateTime.Parse("2019-12-14"),
                        Notes ="Repainted unit",
                        Cost = 800,
                        Paid = true
                    },
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "Edmonds Landscaping").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("503 7th Ave")).BuildingID,
                        UnitID = null,
                        StartDate = DateTime.Parse("2019-01-01"),
                        FinishDate = DateTime.Parse("2019-01-03"),
                        Notes ="Cut the grass",
                        Cost = 500,
                        Paid = true
                    },
                    new RepairHistory
                    {
                        ContractorID = contractors.Single(c => c.Company == "A&E Construction").ContractorID,
                        BuidlingID = buildings.Single(b=>b.Address.Equals("417 4th Ave N")).BuildingID,
                        UnitID = null,
                        StartDate = DateTime.Parse("2019-02-01"),
                        FinishDate = DateTime.Parse("2019-06-06"),
                        Notes ="Paved the parking lot",
                        Cost = 10000,
                        Paid = true
                    }
                };
            context.RepairHistories.AddRange(repairHistories);
            context.SaveChanges();
            var tenants = new Tenant[]
                {
                    new Tenant {FirstName = "Nathan", LastName = "O'Brien", Employment = "Developer", Salary = 132000,PhoneNumber="206-450-2788"},
                    new Tenant {FirstName = "Donald", LastName = "Duck", Employment = "Disney", Salary = 78000,PhoneNumber="213-877-8960"},
                    new Tenant {FirstName = "Shrek", LastName = "Swamp", Employment = "Self Employed", Salary = 120000 ,PhoneNumber="213-613-2953"},
                    new Tenant {FirstName = "Lord", LastName = "Farquad", Employment = "Ruler", Salary = 95000,PhoneNumber="213-236-0238"},
                    new Tenant {FirstName = "Don", LastName = "Corleone", Employment = "The Mob", Salary = 470000 ,PhoneNumber="206-709-4594"},
                    new Tenant {FirstName = "Ryan", LastName = "Gosling", Employment = "Actor", Salary = 5500000,PhoneNumber="213-520-3215"},
                    new Tenant {FirstName = "Alice", LastName = "Cooper", Employment = "Rock", Salary = 650000 ,PhoneNumber="213-529-9730"},
                    new Tenant {FirstName = "Donald", LastName = "Trump", Employment = "President", Salary = 450000,PhoneNumber="206-984-9324"},
                    new Tenant {FirstName = "Vincent", LastName = "Price", Employment = "Horror Films", Salary = 36000,PhoneNumber="206-584-1819"},
                    new Tenant {FirstName = "Jeff", LastName = "Lebowski", Employment = "Self Employed", Salary = 27000,PhoneNumber="213-525-5175"}
                };
            context.Tenants.AddRange(tenants);
            context.SaveChanges();
            var tenantUnits = new TenantUnit[]
                {
                    //Current Residents with 6 Month Lease
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "A").UnitID,
                        MovedInDate = DateTime.Parse("2020-06-01"),
                        MovedOutDate = DateTime.Parse("2020-12-01"),
                        Rent = 2200
                    },
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Duck").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "B").UnitID,
                        MovedInDate = DateTime.Parse("2020-03-01"),
                        MovedOutDate = DateTime.Parse("2020-09-01"),
                        Rent = 2500
                    },
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Swamp").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "1").UnitID,
                        MovedInDate = DateTime.Parse("2020-04-01"),
                        MovedOutDate = DateTime.Parse("2020-10-01"),
                        Rent = 1200
                    },
                    //Past Residents with 6 Month Lease
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "2").UnitID,
                        MovedInDate = DateTime.Parse("2019-05-01"),
                        MovedOutDate = DateTime.Parse("2019-11-01"),
                        Rent = 2600
                    },
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "1B").UnitID,
                        MovedInDate = DateTime.Parse("2019-02-01"),
                        MovedOutDate = DateTime.Parse("2019-08-01"),
                        Rent = 3200
                    },
                    //Current Residents with 12 Month Lease
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "1C").UnitID,
                        MovedInDate = DateTime.Parse("2019-08-01"),
                        MovedOutDate = DateTime.Parse("2020-08-01"),
                        Rent = 2200
                    },
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "1A").UnitID,
                        MovedInDate = DateTime.Parse("2019-10-01"),
                        MovedOutDate = DateTime.Parse("2020-10-01"),
                        Rent = 2100
                    },
                    //Past Residents with 12 Month Lease
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Trump").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "1A").UnitID,
                        MovedInDate = DateTime.Parse("2017-07-01"),
                        MovedOutDate = DateTime.Parse("2018-07-01"),
                        Rent = 2500
                    },
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Price").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "D").UnitID,
                        MovedInDate = DateTime.Parse("2018-12-01"),
                        MovedOutDate = DateTime.Parse("2019-12-01"),
                        Rent = 1700
                    },
                    new TenantUnit
                    {
                        TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID,
                        UnitID = units.Single(u => u.UnitNumber == "A").UnitID,
                        MovedInDate = DateTime.Parse("2017-06-01"),
                        MovedOutDate = DateTime.Parse("2018-06-01"),
                        Rent = 1800
                    },
                };
            context.TenantUnits.AddRange(tenantUnits);
            context.SaveChanges();
            var infractions = new Infraction[]
                {
                    //paid this year
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-03-01"), Reason = "Quacking loudly at residents", Amount = 100, Paid = true},
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-04-01"), Reason = "Chasing residents dogs", Amount = 200, Paid = true},
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-02-01"), Reason = "Loud hollywood style party", Amount = 1700, Paid = true},
                    //unpaid this year
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-05-01"), Reason = "Throwing furniture off of balcony", Amount = 500, Paid = false},
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-03-01"), Reason = "Loud hollywood style party", Amount = 1800, Paid = false},
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-01-01"), Reason = "Hosting rock concert in living room", Amount = 1000, Paid = false},
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-02-01"), Reason = "Balcony space is unsightly and requires cleaning", Amount = 100, Paid = false},
                    //paid last year
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2019-09-01"), Reason = "Loud hollywood style party", Amount = 1000, Paid = true},
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-06-01"), Reason = "Murder of Forest Creatures", Amount = 1000, Paid = true},
                    new Infraction {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2019-12-01"), Reason = "Playing guitar on the balcony", Amount = 2000, Paid = true},
                };
            context.Infractions.AddRange(infractions);
            context.SaveChanges();
            var rentPayments = new RentPayment[]
                {
                    //nathans rent payments
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, Date = DateTime.Parse("2020-06-01"), Amount = 2200},
                    //ducks rent payments
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-03-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-04-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-05-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, Date = DateTime.Parse("2020-06-01"), Amount = 2500},
                    //Swamps payments //missing a payment
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Swamp").TenantID, Date = DateTime.Parse("2020-04-01"), Amount = 1200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Swamp").TenantID, Date = DateTime.Parse("2020-05-01"), Amount = 1200},
                    //Farquads
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-05-01"), Amount = 2600},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-06-01"), Amount = 2600},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-07-01"), Amount = 2600},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-08-01"), Amount = 2600},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-09-01"), Amount = 2600},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-10-01"), Amount = 2600},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, Date = DateTime.Parse("2019-11-01"), Amount = 2600},
                    //corleones paaym,ents
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2019-02-01"), Amount = 3200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2019-03-01"), Amount = 3200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2019-04-01"), Amount = 3200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2019-05-01"), Amount = 3200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2019-06-01"), Amount = 3200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2019-07-01"), Amount = 3200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, Date = DateTime.Parse("2019-08-01"), Amount = 3200},
                    //Goslings missing a payment
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2019-8-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2019-9-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2019-10-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2019-11-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2019-12-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-1-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-2-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-3-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-4-01"), Amount = 2200},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, Date = DateTime.Parse("2020-5-01"), Amount = 2200},
                    //coppers rent
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2019-10-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2019-11-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2019-12-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-01-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-02-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-03-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-04-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-05-01"), Amount = 2100},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, Date = DateTime.Parse("2020-06-01"), Amount = 2100},
                    //Trumps rent
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2017-07-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2017-08-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2017-09-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2017-10-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2017-11-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2017-12-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2018-01-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2018-02-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2018-03-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2018-04-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2018-05-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2018-06-01"), Amount = 2500},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, Date = DateTime.Parse("2018-07-01"), Amount = 2500},
                    //price
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2018-12-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-01-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-02-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-03-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-04-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-05-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-06-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-07-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-08-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-09-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-10-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-11-01"), Amount = 1700},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, Date = DateTime.Parse("2019-12-01"), Amount = 1700},

                    //lebowski
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2017-06-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2017-07-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2017-08-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2017-09-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2017-10-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2017-11-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2017-12-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2018-01-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2018-02-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2018-03-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2018-04-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2018-05-01"), Amount = 1800},
                    new RentPayment {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, Date = DateTime.Parse("2018-06-01"), Amount = 1800},

                };

                context.RentPayments.AddRange(rentPayments);
                context.SaveChanges();
                var vehicles = new Vehicle[]
                    {
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, LicensePlate = "GETR3KT", Make = "Ferrari", Model="812 Superfast", Year = 2013, Color = "Purple"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "O'Brien").TenantID, LicensePlate = "GE7B3KL", Make = "Tesla", Model="Model 3", Year = 2015, Color = "Red"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Duck").TenantID, LicensePlate = "DUCKIT", Make = "Volvo", Model="XC60", Year = 1999, Color = "Red"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Swamp").TenantID, LicensePlate = "AMFTHER", Make = "Lincoln", Model="MKZ", Year = 1995, Color = "Green"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Farquad").TenantID, LicensePlate = "BESTCAR", Make = "Tesla", Model="Model S", Year = 3000, Color = "Orange"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Corleone").TenantID, LicensePlate = "A123QZP", Make = "Mercury", Model="Cougar", Year = 2020, Color = "Blue"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Gosling").TenantID, LicensePlate = "AMURGOD", Make = "Buick", Model="Enclave", Year = 1966, Color = "Black"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Cooper").TenantID, LicensePlate = "MAKIK", Make = "Ford", Model="F-150", Year = 2007, Color = "Silver"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Trump").TenantID, LicensePlate = "DONNY", Make = "Honda", Model="Accord ", Year = 2001, Color = "Grey"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Price").TenantID, LicensePlate = "FASTER", Make = "Hyundai", Model="Kona ", Year = 2000, Color = "White"},
                        new Vehicle {TenantID = tenants.Single(t => t.LastName == "Lebowski").TenantID, LicensePlate = "WILRAGE", Make = "Porsche", Model="Cayenne", Year = 1992, Color = "Yellow"},

                    };
                context.Vehicles.AddRange(vehicles);
                context.SaveChanges();
        }
        public static void ClearDb(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Buildings.Any())
            {
                context.Buildings.RemoveRange(context.Buildings);
            }
            if (context.Units.Any())
            {
                context.Units.RemoveRange(context.Units);
            }
            if (context.Contractors.Any())
            {
                context.Contractors.RemoveRange(context.Contractors);
            }
            if (context.RepairHistories.Any())
            {
                context.RepairHistories.RemoveRange(context.RepairHistories);
            }
            if (context.Tenants.Any())
            {
                context.Tenants.RemoveRange(context.Tenants);
            }
            if (context.TenantUnits.Any())
            {
                context.TenantUnits.RemoveRange(context.TenantUnits);
            }
            if (context.Infractions.Any())
            {
                context.Infractions.RemoveRange(context.Infractions);
            }
            if (context.RentPayments.Any())
            {
                context.RentPayments.RemoveRange(context.RentPayments);
            }
            if (context.Vehicles.Any())
            {
                context.Vehicles.RemoveRange(context.Vehicles);
            }
            context.SaveChanges();
        }
    }

}
