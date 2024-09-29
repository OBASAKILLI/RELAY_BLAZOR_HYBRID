using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PROJECT.Models
{
    public class Users
    {
        [Key]
        [MaxLength(50)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string strId { get; set; }
        [Required(ErrorMessage ="Required Field")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string Phone { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string provider { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string profileBio { get; set; } = string.Empty;
    }
}
