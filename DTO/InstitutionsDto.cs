
namespace Api_Antivirus.DTO
{
    public class InstitutionsResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Ubication { get; set; }

        public string? url_generalidades { get; set; }

        public string? url_oferta_academica { get; set; }

        public string? url_bienestar { get; set; }

        public string? url_admision { get; set; }
        public string? Logo { get; set; }

    }

    public class InstitutionsRequestDto
    {
        public string Name { get; set; } = null!;

        public string? Ubication { get; set; }

        public string? url_generalidades { get; set; }

        public string? url_oferta_academica { get; set; }

        public string? url_bienestar { get; set; }

        public string? url_admision { get; set; }

        public string? Logo { get; set; }
    }
}