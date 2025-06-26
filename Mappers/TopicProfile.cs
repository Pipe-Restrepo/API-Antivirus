using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<topics, TopicResponseDto>().ReverseMap();            
            CreateMap<topics, TopicRequestDto>().ReverseMap();

            CreateMap<TopicRequestDto, topics>().ReverseMap();
            CreateMap<TopicRequestDto, topics>().ReverseMap();
    }
    }
}