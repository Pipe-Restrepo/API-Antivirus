
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class InstitutionsService : IInstitutions
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public InstitutionsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InstitutionsResponseDto> CreateAsync(InstitutionsRequestDto dto)
        {
            var institution = _mapper.Map<institutions>(dto); // Convertir DTO a entidad
            _context.institutions.Add(institution);
            await _context.SaveChangesAsync(); // Guardar en la BD y generar ID

            return _mapper.Map<InstitutionsResponseDto>(institution); // Retornar la institución creada con ID
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.institutions.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InstitutionsResponseDto>> GetAllAsync()
        {
            var entities = await _context.institutions.ToListAsync();
            return _mapper.Map<IEnumerable<InstitutionsResponseDto>>(entities);
        }

        public async Task<InstitutionsResponseDto> GetByIdAsync(int id)
        {
            var entity = await _context.institutions.FindAsync(id);
            return _mapper.Map<InstitutionsResponseDto>(entity);
        }

        public async Task UpdateAsync(int id, InstitutionsRequestDto dto)
        {
            var entity = await _context.institutions.FindAsync(id);
            if (entity != null)
            {
                entity.name = dto.Name;
                entity.ubication = dto.Ubication;
                entity.url_generalidades = dto.url_generalidades;
                entity.url_oferta_academica = dto.url_oferta_academica;
                entity.url_bienestar = dto.url_bienestar;
                entity.url_admision = dto.url_admision;
                await _context.SaveChangesAsync();
            }
        }
    }
}