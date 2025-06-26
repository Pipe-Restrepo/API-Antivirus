using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Api_Antivirus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowVercel")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            _logger.LogInformation("Ping endpoint called from {Origin}", 
                HttpContext.Request.Headers["Origin"].FirstOrDefault() ?? "unknown");
            
            return Ok(new { 
                message = "Backend conectado correctamente", 
                timestamp = DateTime.UtcNow,
                server = Environment.MachineName,
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            _logger.LogInformation("Health check requested");
            
            return Ok(new { 
                status = "healthy", 
                timestamp = DateTime.UtcNow,
                version = "1.0.0"
            });
        }

        [HttpOptions("ping")]
        public IActionResult PingOptions()
        {
            _logger.LogInformation("CORS preflight request for ping endpoint");
            return Ok();
        }

        [HttpPost("echo")]
        public IActionResult Echo([FromBody] object data)
        {
            _logger.LogInformation("Echo endpoint called with data");
            
            return Ok(new { 
                received = data,
                timestamp = DateTime.UtcNow,
                message = "Data received successfully"
            });
        }
    }
}