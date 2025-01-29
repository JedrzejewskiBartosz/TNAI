using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNAI.Model.Entities;

namespace TNAI.Dto.Catrgories
{
    public class ProductDto
    {
        public ProductDto(Product p)
        {
            Id = p.Id;
            Name = p.Name;
            Description = p.Description;
            Price = p.Price;
            CategoryId = p.CategoryId;
            CategoryName = p.Category.Name;
        }
        
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

    }
}

