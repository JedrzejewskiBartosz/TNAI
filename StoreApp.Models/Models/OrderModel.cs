using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public List<ProductModel> Products { get; set; }
        public double TotalPrice { get; set; } = 0;

        public int OrderDetailsId { get; set; }
        [ForeignKey("OrderDetailsId")]
        public OrderDetailsModel OrderDetails { get; set; }

        public string State { get; set; } = "Pending";

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUserModel ApplicationUser { get; set; }

        public OrderModel(OrderDetailsModel details, List<ProductModel> products, string userID)
        {
            OrderDetails = details;
            Id = 0;
            Products = products;
            State = "Pending";
            TotalPrice = products.Sum(it => it.Price);
            ApplicationUserId = userID;
        }

        public OrderModel()
        {
            Products = new List<ProductModel>();
            State = "Pending";
        }
    }
}
