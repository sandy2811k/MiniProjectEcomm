using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectEcomm.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Cid { get; set; }

        [Required]
        public string? Cname { get; set; }
    }
}
