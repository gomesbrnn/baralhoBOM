using AutoMapper;
using BaralhoBom.API.DTO;
using BaralhoBom.API.Model;

namespace BaralhoBom.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, CreatePlayerDTO>().ReverseMap();
            CreateMap<Game, CreateGameDTO>().ReverseMap();
        }
    }
}