using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TNAI.Dto.Products;

namespace TNAI.Dto.Orders
{
    public class OrderInputDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public virtual ICollection<ProductInputDto>? Products { get; set; }
    }
}
