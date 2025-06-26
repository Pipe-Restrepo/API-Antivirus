using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<categories, CategoriesResponseDto>().ReverseMap();            
            CreateMap<categories, CategoriesRequestDto>().ReverseMap();

            CreateMap<CategoriesRequestDto, categories>().ReverseMap();
            CreateMap<CategoriesRequestDto, categories>().ReverseMap();
        }
    }
}