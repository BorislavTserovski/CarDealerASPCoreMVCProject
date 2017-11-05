using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models.Cars;
using CarDealer.Data;
using CarDealer.Models.Parts;

namespace CarDealer.Services
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CarModel> AllByMake(string make)
        {
            var result = this.db.Cars.Select(c => new CarModel
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance
            })
            .Where(c=>c.Make==make)
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TravelledDistance)
            .ToList();

            return result;
        }

        public IEnumerable<CarWithPartsModel> AllWithParts()
        {
            var result = this.db.Cars.Select(c => new CarWithPartsModel
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                Parts = c.Parts.Select(p => new PartModel
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price

                })
            }).ToList();

            return result;
        }
    }
}
