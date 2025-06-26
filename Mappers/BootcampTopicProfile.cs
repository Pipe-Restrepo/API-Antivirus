using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class BootcampTopicProfile : Profile
    {
        public BootcampTopicProfile()
        {
            CreateMap<bootcamp_topics, BootcampTopicResponseDto>().ReverseMap();            
            CreateMap<bootcamp_topics, BootcampTopicRequestDto>().ReverseMap();

            CreateMap<BootcampTopicRequestDto, bootcamp_topics>().ReverseMap();
            CreateMap<BootcampTopicRequestDto, bootcamp_topics>().ReverseMap();
        }
    }
}