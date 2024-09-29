using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PROJECT.Models
{
    public class Products
    {
        [Key]
        [MaxLength(50)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string strId { get; set; }
        public string strImageUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public double strPrice { get; set; }
        public string stDescription { get; set; } = string.Empty;
        public double strPrevPrice { get; set; }
        public string CategoryId { get; set; } = string.Empty;
        public string Sub_CategoryId { get; set; } = string.Empty;
        public string strStoreId { get; set; } = string.Empty;
        public int strQuantity { get; set; }
        public string strTitle { get; set; } = string.Empty;
        public int strReviews { get; set; }
        public int strVisits { get; set; }
    }
}
