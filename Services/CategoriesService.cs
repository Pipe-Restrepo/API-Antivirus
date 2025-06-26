
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class CategoriesService : ICategories
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public CategoriesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoriesResponseDto> CreateAsync(CategoriesRequestDto dto)
        {
            var category = _mapper.Map<categories>(dto); // Convertir DTO a entidad
            _context.categories.Add(category);
            await _context.SaveChangesAsync(); // Guardar en la BD y generar ID

            return _mapper.Map<CategoriesResponseDto>(category); // Retornar la categoría creada con ID
        }

        public async Task DeleteAsync(int  id)
        {
            var entity = await _context.categories.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoriesResponseDto>> GetAllAsync()
        {
            var entities = await _context.categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoriesResponseDto>>(entities);
        }

        public async Task<CategoriesResponseDto> GetByIdAsync(int  id)
        {
            var entity = await _context.categories.FindAsync(id);
            return _mapper.Map<CategoriesResponseDto>(entity);
        }

        public async Task UpdateAsync(int id, CategoriesRequestDto dto)
        {
            var entity = await _context.categories.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            entity.name = dto.Name;
            entity.description = dto.Description;
            
            await _context.SaveChangesAsync();
        }
    }
}