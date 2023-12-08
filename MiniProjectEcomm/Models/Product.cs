using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectEcomm.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Pid { get; set; }

        [Required]
        public string? Pname { get; set; }


        [Required]
        public decimal Price { get; set; }


        public string? ImageUrl { get; set; }

        [ForeignKey("Cid")]
        public int Cid { get; set; }

    }
}
