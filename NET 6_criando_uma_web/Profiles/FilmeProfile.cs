using AutoMapper;
using NET_6_criando_uma_web.Data.Dtos.Movie;
using NET_6_Relacionando_Entidades.Models;

namespace NET_6_Relacionando_Entidades.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>()
                .ForMember(filmeDto => filmeDto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes));
        }
    }
}
