
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class BootcampTopicService : IBootcampTopic
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public BootcampTopicService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(BootcampTopicRequestDto dto)
        {
            var entity = _mapper.Map<bootcamp_topics>(dto);
            _context.bootcamp_topics.Add(entity);
            await _context.SaveChangesAsync();
            _mapper.Map<BootcampTopicRequestDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.bootcamp_topics.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BootcampTopicResponseDto>> GetAllAsync()
        {
            var entities = await _context.bootcamp_topics.ToListAsync();
            return _mapper.Map<IEnumerable<BootcampTopicResponseDto>>(entities);
        }

        public async Task<BootcampTopicResponseDto> GetByIdAsync(int id)
        {
            var entity = await _context.bootcamp_topics.FindAsync(id);
            return _mapper.Map<BootcampTopicResponseDto>(entity);
        }

        public async Task UpdateAsync(int id, BootcampTopicRequestDto dto)
        {
            var entity = await _context.bootcamp_topics.FindAsync(id);
            if (entity != null)
            {
                entity.bootcamp_id = dto.Bootcamp_id;
                entity.topic_id = dto.Topic_id;
                await _context.SaveChangesAsync();
            }
        }
    }
}