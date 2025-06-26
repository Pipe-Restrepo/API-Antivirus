using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IBootcamp
    {
        Task<IEnumerable<BootcampResponseDto>> GetAllAsync();
        Task<BootcampResponseDto> GetByIdAsync(int id);
        Task CreateAsync(BootcampRequestDto dto);
        Task UpdateAsync(int id, BootcampRequestDto dto);
        Task DeleteAsync(int id);
    }
}