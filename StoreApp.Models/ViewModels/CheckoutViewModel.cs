using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; }

        public double GetCombinedCost()
        {
            return Products.Sum(x => x.Price);
        }
    }
}
