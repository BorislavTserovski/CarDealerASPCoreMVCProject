using CarDealer.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Services
{
    public interface ISupplierService
    {

        IEnumerable<SupplierModel> GetSuppliersByPartsOrigin(string origin);
    }
}
