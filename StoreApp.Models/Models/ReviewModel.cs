using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    public class ReviewModel
    {
        [Key]
        public int ReviewId { get; set; }
        [StringLength(250)]
        public string? Title { get; set; }
        [StringLength(1000)]
        public string? Description {  get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUserModel ApplicationUser { get; set; }
    }
}
