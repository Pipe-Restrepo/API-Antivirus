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
    public class UserOpportunities : ControllerBase
    {
        private readonly IUserOpportunities _service;

        public UserOpportunities(IUserOpportunities service)
        {
            _service = service;
        }

                [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOpportunitiesResponseDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserOpportunitiesResponseDto>> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        //consulta por user
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserOpportunitiesForUser (int userId)
        {
            var opportunities = await _service.GetUserOpportunitiesDetailedAsync(userId);

            if (opportunities == null || !opportunities.Any())
            {
                return NotFound("No se encontraron oportunidades guardadas");
            }
            return Ok(opportunities);
        }

        [HttpGet("exists")] // este es para favoritos pero en opportunity
        public async Task<ActionResult<int?>> CheckIfExists([FromQuery] int user_id, [FromQuery] int opportunity_id)
        {
            var favoriteID = await _service.GetFavoriteIdAsync(user_id, opportunity_id);
            if (favoriteID == null)
            {
                return NotFound(); //devuelve un 404 si no existe
            }
            return Ok(favoriteID); //devuelve el id de la relacion
        }

        [HttpPost]
        public async Task<ActionResult<UserOpportunitiesResponseDto>> Create([FromBody] UserOpportunitiesRequestDto dto)
        {   

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdOpportunity = await _service.CreateAsync(dto); // Recibe el objeto con ID generado
            return CreatedAtAction(nameof(Get), new { id = createdOpportunity.Id }, createdOpportunity); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserOpportunitiesRequestDto dto)
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
            
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }

        private bool IsAdmin()
        {
           var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "rol")?.Value;
            return role == "admin";
        }
    }
}