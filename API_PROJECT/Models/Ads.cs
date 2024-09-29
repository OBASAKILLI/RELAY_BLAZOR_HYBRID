using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_PROJECT.Models
{
    public class Ads
    {
        [Key]
        [MaxLength(50)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string strId { get; set; }
        public string strBusinessId { get; set; }=string.Empty;
        public string strImageUrl { get; set; } = string.Empty;
    }
}
