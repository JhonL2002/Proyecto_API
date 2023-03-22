using System.ComponentModel.DataAnnotations;

namespace Proyecto_API.Models.Dto
{
    //Este dto permite usar datos nuevos en lugar de las entidades (Modelos)
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Occupants { get; set; }

        public int SquareMeter { get; set; }

        public string Detail { get; set; }

        [Required]
        public double Fee { get; set; }

        public string UrlImage { get; set; }

        public int Amenity { get; set; }

    }
}
