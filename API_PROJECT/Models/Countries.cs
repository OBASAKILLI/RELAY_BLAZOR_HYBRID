using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_PROJECT.Models
{
    public class Countries
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string CapitalCity { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string Continent { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Field")]
        public string Nationality { get; set; } = string.Empty;

    }
}
