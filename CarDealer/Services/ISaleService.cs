using CarDealer.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Services
{
   public interface ISaleService
    {
        IEnumerable<SaleWithDiscountModel> All();

        SaleWithDiscountModel SaleById(int id);

        IEnumerable<SaleWithDiscountModel> DiscountedSales();

        IEnumerable<SaleWithDiscountModel> DiscountedSalesByGivenPercent(decimal percent);


    }
}
