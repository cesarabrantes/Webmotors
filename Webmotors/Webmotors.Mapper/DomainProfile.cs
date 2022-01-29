using AutoMapper;
using Webmotors.Domain.Models;
using Webmotors.ViewModel;

namespace Webmotors.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<AnuncioWebmotors, AnuncioWebmotorsVM>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
        }
    }
}
