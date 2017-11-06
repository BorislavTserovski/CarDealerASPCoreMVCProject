using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models.Sales;
using CarDealer.Data;
using CarDealer.Models.Cars;
using CarDealer.Models.Customers;
using CarDealer.Data.Models;

namespace CarDealer.Services
{
    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleWithDiscountModel> All()
        {
            var result = this.db.Sales.Select(s => new SaleWithDiscountModel
            {
                PriceWithoutDiscount = s.Car.Parts.Sum(p=>p.Part.Price),
                PriceWithDiscount = s.Car.Parts.Sum(p => p.Part.Price) - s.Discount*(s.Car.Parts.Sum(p => p.Part.Price)/100),
                Car = new CarModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                Customer = new CustomerModel
                {
                    Name = s.Customer.Name,
                    BirthDate = s.Customer.BirthDate,
                    IsYoungDriver = s.Customer.IsYoungDriver
                }
            }).ToList();

            return result;
        }

        public IEnumerable<SaleWithDiscountModel> DiscountedSales()
        {
            var result = this.db.Sales.Select(s => new SaleWithDiscountModel
            {
                Car = new CarModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                Customer = new CustomerModel
                {
                    Name = s.Customer.Name,
                    BirthDate = s.Customer.BirthDate,
                    IsYoungDriver = s.Customer.IsYoungDriver
                },
                PriceWithoutDiscount = s.Car.Parts.Sum(p => p.Part.Price),
                PriceWithDiscount = s.Car.Parts.Sum(p => p.Part.Price) - s.Discount * (s.Car.Parts.Sum(p => p.Part.Price) / 100)

            }).Where(s => s.PriceWithDiscount != s.PriceWithoutDiscount)
            .ToList();
            return result;
        }

        public IEnumerable<SaleWithDiscountModel> DiscountedSalesByGivenPercent(decimal percent)
        {
            throw new NotImplementedException();
        }

        public SaleWithDiscountModel SaleById(int id)
        {
            Sale sale = this.db.Sales.Find(id);
            Car car = db.Cars.FirstOrDefault(c => c.Id == sale.CarId);
            Customer customer = db.Customers.FirstOrDefault(cu => cu.Id == sale.CustomerId);
            var result = new SaleWithDiscountModel
            {
                Car = new CarModel
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                },
                Customer = new CustomerModel
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsYoungDriver = customer.IsYoungDriver
                },
                PriceWithoutDiscount = sale.Car.Parts.Sum(p => p.Part.Price),
                PriceWithDiscount = sale.Car.Parts.Sum(p => p.Part.Price) - sale.Discount * (sale.Car.Parts.Sum(p => p.Part.Price) / 100)

            };

            return result;
        }
    }
}
