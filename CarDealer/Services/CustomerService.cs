using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models.Customers;
using CarDealer.Data;

namespace CarDealer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> All(string order)
        {
            if (order.ToLower() == "descending")
            {
                var result = db.Customers.Select(c => new CustomerModel
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .OrderByDescending(cm => cm.BirthDate)
                .ToList();

                return result;

            }
            else if (order.ToLower() == "ascending")
            {
                var result = db.Customers.Select(c => new CustomerModel
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
               .OrderBy(cm => cm.BirthDate)
               .ToList();

                return result;
            }
            else return new List<CustomerModel>();
        }

        public CustomerWithCarsModel CustomerWithCars(int id)
        {
            var result = db.Customers.Where(c => c.Id == id).Select(c => new CustomerWithCarsModel
            {
                Id = c.Id,
                Name = c.Name,
                CarsBought = c.Sales.Count,
                MoneySpent = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Part.Price))

            }).FirstOrDefault();

            return result;
        }
    }
}
