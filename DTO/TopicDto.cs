
namespace Api_Antivirus.DTO
{
    public class TopicResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


    }

    public class TopicRequestDto
    {
        public string Name { get; set; } = null!;

    }
}