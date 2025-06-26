
using Api_Antivirus.Models;

namespace Api_Antivirus.DTO
{
    public class OpportunitiesResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Observation { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public string? Requires { get; set; }

        public string? Guide { get; set; }

        public string? adicional_dates { get; set; }

        public string? service_channels { get; set; }

        public string? Manager { get; set; }

        public string? Modality { get; set; }

        public int category_id { get; set; }

        public int institution_id { get; set; }

    }

    public class OpportunitiesRequestDto
    {
        public string Name { get; set; } = null!;

        public string? Observation { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public string? Requires { get; set; }

        public string? Guide { get; set; }

        public string? adicional_dates { get; set; }

        public string? service_channels { get; set; }

        public string? Manager { get; set; }

        public string? Modality { get; set; }

        public int category_id { get; set; }

        public int institution_id { get; set; }
    }

    public class OpportunitiesConsultDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Observation { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public string? Requires { get; set; }

        public string? Guide { get; set; }

        public string? adicional_dates { get; set; }

        public string? service_channels { get; set; }

        public string? Manager { get; set; }

        public string? Modality { get; set; }

        public int category_id { get; set; }

        public int? institution_id { get; set; }  // Se mantiene el ID por compatibilidad
        public InstitutionCustomDto? Institution { get; set; } // Opcional: más datos de la institución
    }
    public class InstitutionCustomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public required string Logo { get; set; }
        public string ubication { get; set; }
        public string url_generalidades { get; set; }
        public string url_oferta_academica { get; set; }
        public string url_bienestar { get; set; }
         public string url_admision { get; set; }
        
    }
}