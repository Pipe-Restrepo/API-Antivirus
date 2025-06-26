using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IInstitutions
    {
        Task<IEnumerable<InstitutionsResponseDto>> GetAllAsync();
        Task<InstitutionsResponseDto> GetByIdAsync(int id);
        Task<InstitutionsResponseDto> CreateAsync(InstitutionsRequestDto dto);
        Task UpdateAsync(int id, InstitutionsRequestDto dto);
        Task DeleteAsync(int id);
    }
}