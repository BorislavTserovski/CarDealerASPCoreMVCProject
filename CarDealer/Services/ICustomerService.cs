using CarDealer.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> All(string order);

        CustomerWithCarsModel CustomerWithCars(int id);

        void Add(string name, DateTime birthDate);

        CustomerModel Edit(int id);

        void Edit(int id,CustomerModel model);
    }
}
