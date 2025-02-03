using TNAI.Model.Entities;

namespace TNAI.Dto.Products
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
            ImageFile = p.ImageFile;
            CategoryName = p.Category.Name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? ImageFile { get; set; }
        public string CategoryName { get; set; }

    }
}

