using AutoMapper;
using NET_6_criando_uma_web.Data.Dtos.Session;
using NET_6_criando_uma_web.Models;

namespace NET_6_criando_uma_web.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}
