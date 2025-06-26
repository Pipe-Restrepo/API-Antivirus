using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcamp _service;

        public BootcampController(IBootcamp service)
        {
            _service = service;
        }

        // Solo usuarios autenticados pueden acceder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BootcampResponseDto>>> GetAll()
        {   
            if (!IsAdmin()) return Forbid();
            
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BootcampResponseDto>> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        // Métodos restringidos a administradores
        [HttpPost]
        public async Task<ActionResult<BootcampResponseDto>> Create([FromBody] BootcampRequestDto dto)
        {
            if (!IsAdmin()) return Forbid(); // Si no es admin, devolver 403 Forbidden

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BootcampRequestDto dto)
        {
            if (!IsAdmin()) return Forbid();

            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!IsAdmin()) return Forbid();

            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }

        // Método privado para verificar si el usuario tiene rol "admin"
        private bool IsAdmin()
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "rol")?.Value;
            return role == "admin";
        }
    }
}
