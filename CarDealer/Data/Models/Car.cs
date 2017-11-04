using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        public string Model { get; set; }

        //in km
        [Range(0,long.MaxValue)]
        public long TravelledDistance { get; set; }

        public List<PartCars> Parts { get; set; } = new List<PartCars>();

        public List<Sale> Sales { get; set; } = new List<Sale>();

    }
}
