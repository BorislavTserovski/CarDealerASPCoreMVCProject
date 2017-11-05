using CarDealer.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Services
{
    public interface ICarService
    {
        IEnumerable<CarModel> AllByMake(string make);

        IEnumerable<CarWithPartsModel> AllWithParts();
    }
}
