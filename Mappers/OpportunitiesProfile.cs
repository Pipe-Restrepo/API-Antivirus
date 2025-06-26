using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class OpportunitiesProfile : Profile
    {
        public OpportunitiesProfile()
        {
            CreateMap<opportunities, OpportunitiesResponseDto>().ReverseMap();
            CreateMap<opportunities, OpportunitiesRequestDto>().ReverseMap();

            CreateMap<OpportunitiesRequestDto, opportunities>().ReverseMap();
            CreateMap<OpportunitiesRequestDto, opportunities>().ReverseMap();

            CreateMap<opportunities, OpportunitiesConsultDTO>()
                .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.institution))
                .ReverseMap();
            CreateMap<institutions, InstitutionCustomDto>().ReverseMap();
        }
    }
}