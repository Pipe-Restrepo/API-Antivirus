using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IOpportunities
    {
        Task<IEnumerable<OpportunitiesConsultDTO>> GetAllAsync();
        Task<OpportunitiesResponseDto> GetByIdAsync(int id);
        Task<OpportunitiesResponseDto> CreateAsync(OpportunitiesRequestDto dto);
        Task UpdateAsync(int id, OpportunitiesRequestDto dto);
        Task DeleteAsync(int id);
    }
}