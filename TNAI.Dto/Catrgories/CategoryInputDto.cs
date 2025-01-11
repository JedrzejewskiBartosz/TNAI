using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNAI.Dto.Catrgories
{
    public class CategoryInputDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
