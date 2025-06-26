using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<users, UsersResponseDto>().ReverseMap();            
            CreateMap<users, UsersRequestDto>().ReverseMap();

            CreateMap<UsersRequestDto, users>().ReverseMap();
            CreateMap<UsersRequestDto, users>().ReverseMap();
        }
    }
}