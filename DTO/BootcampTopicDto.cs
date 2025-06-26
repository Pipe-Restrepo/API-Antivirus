
using Api_Antivirus.Models;

namespace Api_Antivirus.DTO
{
    public class BootcampTopicResponseDto
    {
        public int Id { get; set; }

        public int Bootcamp_id { get; set; }

        public int Topic_id { get; set; }

    }

    public class BootcampTopicRequestDto
    {
        public int Bootcamp_id { get; set; }

        public int Topic_id { get; set; }
    }
}