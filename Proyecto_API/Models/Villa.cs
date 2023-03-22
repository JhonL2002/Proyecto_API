using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_API.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Detail { get; set; }

        [Required]
        public double Fee { get; set; }

        public int Occupants { get; set; }

        public int SquareMeter { get; set; }

        public string UrlImage { get; set; }

        public int Amenity { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
