
using Api_Antivirus.Models;

namespace Api_Antivirus.DTO
{
    public class UserOpportunitiesResponseDto
    {
        public int Id { get; set; }
        public int User_id { get; set; }

        public int Opportunity_id { get; set; }

    }

    public class UserOpportunitiesRequestDto
    {
        public int User_id { get; set; }

        public int Opportunity_id { get; set; }
    }

    public class UserOpportunitiesDetailedConsultDTO
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Opportunity_id { get; set; }
        public OpportunitiesConsultDTO? Opportunity { get; set; }

    }
}