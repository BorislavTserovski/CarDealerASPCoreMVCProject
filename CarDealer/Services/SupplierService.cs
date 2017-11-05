using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models.Suppliers;
using CarDealer.Data;

namespace CarDealer.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;
        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> GetSuppliersByPartsOrigin(string origin)
        {
            if (origin.ToLower()=="local")
            {
                var result = db.Suppliers.Where(s => s.IsImporter == false).Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CountOfParts = s.Parts.Count
                })
                .ToList();
                return result;
            }
            else
            {
                var result = db.Suppliers.Where(s => s.IsImporter == true).Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CountOfParts = s.Parts.Count
                })
                .ToList();
                return result;
            }
        }
    }
}
