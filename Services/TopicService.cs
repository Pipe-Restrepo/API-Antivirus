
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class TopicService : ITopic
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public TopicService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(TopicRequestDto dto)
        {
            var entity = _mapper.Map<topics>(dto);
            _context.topics.Add(entity);
            await _context.SaveChangesAsync();
            _mapper.Map<TopicRequestDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.topics.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TopicResponseDto>> GetAllAsync()
        {
            var entities = await _context.topics.ToListAsync();
            return _mapper.Map<IEnumerable<TopicResponseDto>>(entities);
        }

        public async Task<TopicResponseDto> GetByIdAsync(int id)
        {
            var entity = await _context.topics.FindAsync(id);
            return _mapper.Map<TopicResponseDto>(entity);
        }

        public async Task UpdateAsync(int id, TopicRequestDto dto)
        {
            var entity = await _context.topics.FindAsync(id);
            if (entity != null)
            {
                entity.name = dto.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}