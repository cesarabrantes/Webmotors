using AutoMapper;
using Webmotors.Domain.Models;
using Webmotors.ViewModel;

namespace Webmotors.Mapper
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<AnuncioWebmotorsVM, AnuncioWebmotors>();
        }
    }
}
