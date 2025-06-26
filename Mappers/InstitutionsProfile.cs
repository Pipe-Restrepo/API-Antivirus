using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;

namespace Api_Antivirus.Mappers
{
    public class InstitutionsProfile : Profile
    {
        public InstitutionsProfile()
        {
            CreateMap<institutions, InstitutionsResponseDto>().ReverseMap();
            CreateMap<institutions, InstitutionsRequestDto>().ReverseMap();

            CreateMap<InstitutionsRequestDto, institutions>().ReverseMap();
        }
    }
}
