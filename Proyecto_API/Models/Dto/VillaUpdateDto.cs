using System.ComponentModel.DataAnnotations;

namespace Proyecto_API.Models.Dto
{
    //Este dto permite usar datos nuevos en lugar de las entidades (Modelos)
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int Occupants { get; set; }

        [Required]
        public int SquareMeter { get; set; }

        [Required]
        public string Detail { get; set; }

        public double Fee { get; set; }
        [Required]
        public string UrlImage { get; set; }

        public int Amenity { get; set; }

        public DateTime UpdateDate { get; set; } = DateTime.Now;

    }
}
