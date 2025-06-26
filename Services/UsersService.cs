
using System.Security.Claims;
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class UsersService : IUsers
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public UsersService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(UsersRequestDto dto)
        {
            var entity = _mapper.Map<users>(dto);
            _context.users.Add(entity);
            await _context.SaveChangesAsync();
            _mapper.Map<UsersRequestDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.users.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UsersResponseDto>> GetAllAsync()
        {
            var entities = await _context.users.ToListAsync();
            return _mapper.Map<IEnumerable<UsersResponseDto>>(entities);
        }

        public async Task<UsersResponseDto> GetByIdAsync(int id)
        {
            var entity = await _context.users.FindAsync(id);
            return _mapper.Map<UsersResponseDto>(entity);
        }

        //configuro la extraccion de datos del token recibido
        public async Task<UsersResponseDto?> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value; //extraigo el Id
            if (userId == null)
            {
                return null;
            }
            var entity = await _context.users.FindAsync(int.Parse(userId));
            return _mapper.Map<UsersResponseDto>(entity);

        }

        public async Task UpdateAsync(int id, UsersRequestDto dto)
        {
            var entity = await _context.users.FindAsync(id);
            if (entity != null)
            {
                entity.name = dto.Name;
                entity.email = dto.Email;
                entity.rol = dto.Rol;

                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    entity.password = dto.Password;
                }

                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateRolAsync(int id, string newRol)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null) throw new KeyNotFoundException("Usuario no encontrado");

            user.rol = newRol;
            await _context.SaveChangesAsync();
        }

    }
}