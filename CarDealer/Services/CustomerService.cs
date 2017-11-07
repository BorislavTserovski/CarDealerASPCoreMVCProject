using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models.Customers;
using CarDealer.Data;
using CarDealer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, DateTime birthDate)
        {
            Customer customer = new Customer()
            {
                
                Name = name,
                BirthDate = birthDate,
                IsYoungDriver =birthDate.Year > 1996
            };
            this.db.Customers.Add(customer);
            this.db.SaveChanges();
        }

        public IEnumerable<CustomerModel> All(string order)
        {
            if (order.ToLower() == "descending")
            {
                var result = db.Customers.Select(c => new CustomerModel
                {
                    Id = c.Id,
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
                    Id = c.Id,
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

        public CustomerModel Edit(int id)
        {
            Customer customer = db.Customers.Find(id);
            CustomerModel model = new CustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                
            };
            return model;
            
        }

        public void Edit(int id,CustomerModel model)
        {
            Customer customer = db.Customers.Find(id);
            customer.Name = model.Name;
            customer.BirthDate = model.BirthDate;
            db.SaveChanges();
        }
    }
}
