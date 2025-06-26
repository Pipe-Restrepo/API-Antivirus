using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface ITopic
    {
        Task<IEnumerable<TopicResponseDto>> GetAllAsync();
        Task<TopicResponseDto> GetByIdAsync(int id);
        Task CreateAsync(TopicRequestDto dto);
        Task UpdateAsync(int id, TopicRequestDto dto);
        Task DeleteAsync(int id);
    }
}