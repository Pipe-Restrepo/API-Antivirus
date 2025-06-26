
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class UserOpportunitiesService : IUserOpportunities
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public UserOpportunitiesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //consulta por Id de usuario
        public async Task <List<UserOpportunitiesDetailedConsultDTO>> GetUserOpportunitiesDetailedAsync (int userId)
        {
            var userOpportunities = await _context.user_opportunities
                .Where(uo => uo.user_id == userId) //filtra el usuario
                .Include(uo => uo.opportunity) // trae los datos de Opportunity
                    .ThenInclude(o => o.institution)// incluye la institucion dentro de opportunity
                .ToListAsync();  
            return _mapper.Map<List<UserOpportunitiesDetailedConsultDTO>>(userOpportunities);
        }

        //consulta desde la url el valor userid y opportunityid
        public async Task<object?> GetFavoriteIdAsync(int userId, int opportunityId)
        {
            var favoriteId = await _context.user_opportunities
                .Where(uo => uo.user_id == userId && uo.opportunity_id == opportunityId)
                .Select(uo => new {id = uo.id}) // devolvemos el ID  en un objeto
                .FirstOrDefaultAsync();

            return favoriteId; //retorna el ID si existe o null 
        }


        public async Task<UserOpportunitiesResponseDto> CreateAsync(UserOpportunitiesRequestDto dto)
        {
            var entity = _mapper.Map<user_opportunities>(dto);
            _context.user_opportunities.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserOpportunitiesResponseDto>(entity);
            
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.user_opportunities.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserOpportunitiesResponseDto>> GetAllAsync()
        {
            var entities = await _context.user_opportunities.ToListAsync();
            return _mapper.Map<IEnumerable<UserOpportunitiesResponseDto>>(entities);
        }

        public async Task<UserOpportunitiesResponseDto> GetByIdAsync(int id)
        {
            var entity = await _context.user_opportunities.FindAsync(id);
            return _mapper.Map<UserOpportunitiesResponseDto>(entity);
        }

        public async Task UpdateAsync(int id, UserOpportunitiesRequestDto dto)
        {
            var entity = await _context.user_opportunities.FindAsync(id);
            if (entity != null)
            {
                entity.user_id = dto.User_id;
                entity.opportunity_id = dto.Opportunity_id;
                await _context.SaveChangesAsync();
            }
        }
    }
}