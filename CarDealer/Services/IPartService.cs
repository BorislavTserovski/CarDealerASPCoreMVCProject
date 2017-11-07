using CarDealer.Models.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Services
{
   public interface IPartService
    {
        IEnumerable<PartModel> All(int page = 1);
        
        void Add(string name, decimal price, string supplierName, int? quantity);
    }
}
