using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class UserOpportunitiesProfile : Profile
    {
        public UserOpportunitiesProfile()
        {
            CreateMap<user_opportunities, UserOpportunitiesResponseDto>().ReverseMap();            
            CreateMap<user_opportunities, UserOpportunitiesRequestDto>().ReverseMap();

            CreateMap<UserOpportunitiesRequestDto, user_opportunities>().ReverseMap();
            CreateMap<UserOpportunitiesResponseDto, user_opportunities>().ReverseMap();

            //mapeos de DetailedConsult
            // Mapeo de UserOpportunities a DTO con detalles
            CreateMap<user_opportunities, UserOpportunitiesDetailedConsultDTO>()
                .ForMember(dest => dest.Opportunity, opt => opt.MapFrom(src => src.opportunity)); //dest.Opportunity es el nombre en el UserOpportunitiesDetailedConsultDTO, src.opportunity el nombre que lleva en la entidad useropportunities

            // Mapeo de Opportunity a OpportunityDto
            CreateMap<opportunities, OpportunitiesConsultDTO>()
                .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.institution));

            // Mapeo de Institution a InstitutionDto
            CreateMap<institutions, InstitutionCustomDto>();
        }
    }
}