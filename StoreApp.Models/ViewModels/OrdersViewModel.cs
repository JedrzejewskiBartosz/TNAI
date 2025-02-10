using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels
{
    public class OrdersViewModel
    {
        public List<OrderModel> PlacedOrders { get; set; }
    }
}
