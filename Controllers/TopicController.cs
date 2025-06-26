using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api_Antivirus.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopic _service;

        public TopicController(ITopic service)
        {
            _service = service;
        }

                [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicResponseDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponseDto>> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TopicResponseDto>> Create([FromBody] TopicRequestDto dto)
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
        public async Task<ActionResult> Update(int id, [FromBody] TopicRequestDto dto)
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

        private bool IsAdmin()
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "rol")?.Value;
            return role == "admin";
        }
    }
}