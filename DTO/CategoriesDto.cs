
namespace Api_Antivirus.DTO
{
    public class CategoriesResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

    }

    public class CategoriesRequestDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}