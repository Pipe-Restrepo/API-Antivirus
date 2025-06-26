using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IUserOpportunities
    {
        Task<IEnumerable<UserOpportunitiesResponseDto>> GetAllAsync();
        Task<UserOpportunitiesResponseDto> GetByIdAsync(int id);
        Task<object?> GetFavoriteIdAsync(int user_id, int opportunity_id);
        Task <List<UserOpportunitiesDetailedConsultDTO>> GetUserOpportunitiesDetailedAsync (int userId); //consulta por user
        Task<UserOpportunitiesResponseDto> CreateAsync(UserOpportunitiesRequestDto dto);
        Task UpdateAsync(int id, UserOpportunitiesRequestDto dto);
        Task DeleteAsync(int id);
    }
}