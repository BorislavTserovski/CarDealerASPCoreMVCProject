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
    }
}
