using AutoMapper;
using Proyecto_API.Models;
using Proyecto_API.Models.Dto;

namespace Proyecto_API
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();

            CreateMap<Villa, VillaCreateDto>().ReverseMap();

            CreateMap<Villa, VillaUpdateDto>().ReverseMap();
        }
    }
}
