using Proyecto_API.Models.Dto;

namespace Proyecto_API.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto{Id=1, Name="Vista a la Piscina", Occupants=2, SquareMeter=300},
            new VillaDto{Id=2, Name="Vista a la Playa", Occupants=4, SquareMeter=600}
        };
    }
}
