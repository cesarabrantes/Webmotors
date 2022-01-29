using AutoMapper;
using Webmotors.Domain.Models;
using Webmotors.Mediator.Api.Models;

namespace Webmotors.Mapper
{
    public class MediatorDomain : Profile
    {
        public MediatorDomain()
        {
            CreateMap<Vehicles, AnuncioWebmotors>()
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.YearModel))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Make))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Quilometragem, opt => opt.MapFrom(src => src.KM))
                .ForMember(dest => dest.Versao, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.Observacao, opt => opt.MapFrom(src => src.YearFab))
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
