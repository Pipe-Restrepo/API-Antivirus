using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _service;

        public UsersController(IUsers service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersResponseDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersResponseDto>> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        // Recibe el token
        [HttpGet("login")]
        public async Task<IActionResult> GetCurrentUser([FromServices] IUsers userService)
        {
            var user = await userService.GetCurrentUserAsync(User);
            if (user == null)
            {
                return Unauthorized(new { error = "No se encontró el usuario" });
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UsersResponseDto>> Create([FromBody] UsersRequestDto dto)
        {   
            if (!IsAdmin()) return Forbid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UsersRequestDto dto)
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

        [HttpDelete]
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

        [HttpPatch("{id}/rol")]
        public async Task<IActionResult> UpdateUserRol(int id, [FromBody] UpdateRolRequest request)
        {
            if (!IsAdmin()) return Forbid();
            
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound("Usuario no encontrado");

            await _service.UpdateRolAsync(id, request.Rol);
            return Ok(new { message = "Rol actualizado correctamente" });
        }

        private bool IsAdmin()
        {
            var rol = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "rol")?.Value;
            return rol == "admin";
        }
    }

    public class UpdateRolRequest
    {
        public string Rol { get; set; }
    }
}
