using AutoMapper;
using NET_6_criando_uma_web.Data.Dtos.EnderecoDto;
using NET_6_criando_uma_web.Models;

namespace NET_6_criando_uma_web.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
