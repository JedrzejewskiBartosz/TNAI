using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels
{
    public class OrderSummaryViewModel
    {
        public OrderDetailsModel OrderDetails { get; set; }
        public DateTime DatePlaced;
        public IEnumerable<OrderProductModel> Products { get; set; }
        public double GetCombinedCost()
        {
            return Products.Sum(x => x.Product.Price);
        }
    }
}
