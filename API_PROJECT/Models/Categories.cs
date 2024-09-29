using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PROJECT.Models
{
    public class Categories
    {
        [Key]
        [MaxLength(50)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string strId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Category { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strImageUrl { get; set; } = string.Empty;
    }
}
