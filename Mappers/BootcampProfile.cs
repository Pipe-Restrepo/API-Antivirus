using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class BootcampProfile : Profile
    {
        public BootcampProfile()
        {
            CreateMap<bootcamps, BootcampResponseDto>().ReverseMap();            
            CreateMap<bootcamps, BootcampRequestDto>().ReverseMap();

            CreateMap<BootcampRequestDto, bootcamps>().ReverseMap();
            CreateMap<BootcampRequestDto, bootcamps>().ReverseMap();
        }
    }
}