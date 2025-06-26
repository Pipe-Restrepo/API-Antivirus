
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class BootcampService : IBootcamp
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BootcampService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(BootcampRequestDto dto)
        {
            var entity = _mapper.Map<bootcamps>(dto);
            _context.bootcamps.Add(entity);
            await _context.SaveChangesAsync();
            _mapper.Map<BootcampRequestDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.bootcamps.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BootcampResponseDto>> GetAllAsync()
        {
            var entities = await _context.bootcamps.ToListAsync();
            return _mapper.Map<IEnumerable<BootcampResponseDto>>(entities);
        }

        public async Task<BootcampResponseDto> GetByIdAsync(int id)
        {
            var entity = await _context.bootcamps.FindAsync(id);
            return _mapper.Map<BootcampResponseDto>(entity);
        }

        public async Task UpdateAsync(int id, BootcampRequestDto dto)
        {
            var entity = await _context.bootcamps.FindAsync(id);
            if (entity != null)
            {
                entity.name = dto.Name;
                entity.description = dto.Description;
                entity.information = dto.Information;
                entity.costs = dto.Costs;
                entity.institution_id = dto.Institution_id;
                await _context.SaveChangesAsync();
            }
        }
    }
}