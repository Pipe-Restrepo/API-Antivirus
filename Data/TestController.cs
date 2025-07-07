using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Api_Antivirus.Data;

namespace Api_Antivirus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowVercel")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ApplicationDbContext _context;

        public TestController(ILogger<TestController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            _logger.LogInformation("Ping endpoint called from {Origin}",
                HttpContext.Request.Headers["Origin"].FirstOrDefault() ?? "unknown");

            return Ok(new
            {
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

            return Ok(new
            {
                status = "healthy",
                timestamp = DateTime.UtcNow,
                version = "1.0.0"
            });
        }

        [HttpGet("db")]
        public async Task<IActionResult> PingDatabase()
        {
            try
            {
                var puedeConectar = await _context.Database.CanConnectAsync();
                _logger.LogInformation("🔌 Conexión a PostgreSQL: {Estado}", puedeConectar);
                return Ok(new
                {
                    conectado = puedeConectar,
                    timestamp = DateTime.UtcNow,
                    baseDatos = _context.Database.ProviderName
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error al conectar con PostgreSQL");
                return StatusCode(500, new
                {
                    error = "Error al intentar conectarse a la base de datos",
                    detalle = ex.Message
                });
            }
        }

        [HttpPost("echo")]
        public IActionResult Echo([FromBody] object data)
        {
            _logger.LogInformation("Echo endpoint called with data");

            return Ok(new
            {
                received = data,
                timestamp = DateTime.UtcNow,
                message = "Data received successfully"
            });
        }

        [HttpOptions("ping")]
        public IActionResult PingOptions()
        {
            _logger.LogInformation("CORS preflight request for ping endpoint");
            return Ok();
        }
    }
}