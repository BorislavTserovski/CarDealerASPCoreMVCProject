using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public List<Part> Parts { get; set; } = new List<Part>();
    }
}
