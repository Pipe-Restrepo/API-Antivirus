using System.Security.Claims;
using Api_Antivirus.DTO;

namespace Api_Antivirus.Interface
{
    public interface IUsers
    {
        Task<IEnumerable<UsersResponseDto>> GetAllAsync();
        Task<UsersResponseDto> GetByIdAsync(int id);
        Task<UsersResponseDto?> GetCurrentUserAsync(ClaimsPrincipal user);
        Task CreateAsync(UsersRequestDto dto);
        Task UpdateAsync(int id, UsersRequestDto dto);
        Task DeleteAsync(int id);
        Task UpdateRolAsync(int id, string newRol);

    }
}