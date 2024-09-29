using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PROJECT.Models
{
    public class Shops
    {
        [Key]
        [MaxLength(50)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string strId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strImageUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strStandardId { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strCountry { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strTown { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strContacts { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string strEmail { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strAbout { get; set; } = string.Empty;
        public bool strIsVIP { get; set; }
        public bool IsApprooved { get; set; }
        public string strFb { get; set; } = string.Empty;
        public string strTwitter { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string strUserId { get; set; } = string.Empty;
        public string strInstagram { get; set; } = string.Empty;
        public string strOpeningHours { get; set; } = string.Empty;
        public string strCustomerCare { get; set; } = string.Empty;

    }
}
