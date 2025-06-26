
using Api_Antivirus.Models;

namespace Api_Antivirus.DTO
{
    public class BootcampResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Information { get; set; }

        public string? Costs { get; set; }

        public int? Institution_id { get; set; }

    }

    public class BootcampRequestDto
    {

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Information { get; set; }

        public string? Costs { get; set; }

        public int? Institution_id { get; set; }

    }
}