using GeekShopping.ProductApi.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi.Model
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string? Name { get; set; }

        [Required]
        [Range(1, 10000)]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? CategoryName { get; set; }

        [Required]
        [StringLength(300)]
        [Column(TypeName = "varchar(300)")]
        public string? ImageUrl { get; set; }
    }
}
