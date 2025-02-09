using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    public class ShoppingCartModel
    {
        [Key]
        public int Id { get; set; }
        public List<int> ProductsID { get; set; } = new();
        [Required] public string ShoppingCartId { get; set; }

        public ShoppingCartModel()
        {
            var cartID = Guid.NewGuid().ToString();
            Id = 0;
            ProductsID = new List<int>();
            ShoppingCartId = cartID;
        }
    }
}
