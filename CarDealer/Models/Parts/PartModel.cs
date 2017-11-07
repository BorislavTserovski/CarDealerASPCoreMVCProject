using CarDealer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models.Parts
{
    public class PartModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string SupplierName { get; set; }

        public int? Quantity { get; set; }
    }
}
