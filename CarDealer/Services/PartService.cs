using CarDealer.Data;
using CarDealer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models.Parts;

namespace CarDealer.Services
{
    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;
        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, decimal price, string supplierName, int? quantity)
        {
            Supplier supplier = db.Suppliers
                .Where(s => s.Name == supplierName)
                .FirstOrDefault();
            Part part = new Part
            {
                Name = name,
                Price = price,
                SupplierId = supplier.Id,
                Quantity = quantity == null ? 1 : quantity
            };
            db.Parts.Add(part);
            
            db.SaveChanges();
        }

        public IEnumerable<PartModel> All(int page = 1)
        {
           return this.db.Parts.OrderByDescending(p => p.Id)
                
                .Select(p => new PartModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    SupplierName = p.Supplier.Name,
                    Quantity = p.Quantity
                }).ToList();
        }
    }
}
