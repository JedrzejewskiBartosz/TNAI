using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    public class OrderProductModel
    {
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
