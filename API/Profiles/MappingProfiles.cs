using Dominio;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Pais, PaisDto>()
            .ForMember(dest => dest.PaisId, opt => opt.MapFrom(src => src.Id ))
            .ForMember(dest => dest.PaisNombre, opt => opt.MapFrom(src => src.NombrePais))
            .ReverseMap();
            CreateMap<Estado, EstadoDto>()
            .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EstadoNombre, opt => opt.MapFrom(src => src.NombreEstado))
            .ForMember(dest => dest.Ciudades, opt => opt.MapFrom(src => src.Regiones))
            .ForMember(dest => dest.IPaisFk, opt => opt.MapFrom(src => src.IdPaisFK))
            .ReverseMap();
            CreateMap<Region, RegionDto>()
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RegionNombre, opt => opt.MapFrom(src => src.NombreRegion))
            .ForMember(dest => dest.IDepFk, opt => opt.MapFrom(src => src.IdEstadoFK))
            .ReverseMap();
            CreateMap<Pais, PaisAllDataDto>()
            .ForMember(dest => dest.PaisId, opt => opt.MapFrom(src => src.Id ))
            .ForMember(dest => dest.PaisNombre, opt => opt.MapFrom(src => src.NombrePais))
            .ForMember(dest => dest.Departamentos, opt => opt.MapFrom(src => src.Estados))
            .ReverseMap();
        }
    }
}