using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IBootcampTopic
    {
        Task<IEnumerable<BootcampTopicResponseDto>> GetAllAsync();
        Task<BootcampTopicResponseDto> GetByIdAsync(int id);
        Task CreateAsync(BootcampTopicRequestDto dto);
        Task UpdateAsync(int id, BootcampTopicRequestDto dto);
        Task DeleteAsync(int id);
    }
}