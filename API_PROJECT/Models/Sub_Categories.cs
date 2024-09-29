using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PROJECT.Models
{
    public class Sub_Categories
    {
        [Key]
        [MaxLength(50)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string strId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Sub_Category { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string CategoryId { get; set; } = string.Empty;
    }
}
