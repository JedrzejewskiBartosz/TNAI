using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNAI.Dto.Products
{
    public class ProductInputDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(5000)]
        public string? Description { get; set; }
        public string? ImageFile { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
