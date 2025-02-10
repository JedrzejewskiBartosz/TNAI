using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StoreApp.Models.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [Display(Name ="Price")]
        [Range(1, 10000)]
        public double Price { get; set; }  

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public CategoryModel? Category { get; set; }
        public string? ImageUrl { get; set; }

        public List<OrderProductModel> OrderProducts { get; set; }

        public ProductModel()
        {

        }

        public ProductModel(OrderProductModel orderProduct)
        {
            Id = orderProduct.ProductId;
            Name = orderProduct.Product.Name;
            Description = orderProduct.Product.Description;
            Price = orderProduct.Product.Price;
            CategoryId = orderProduct.Product.CategoryId;
            ImageUrl = orderProduct.Product.ImageUrl;
        }

    }
}
