using Api_Antivirus.Config;
using Api_Antivirus.Data;
using Api_Antivirus.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Api_Antivirus.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;
        public AuthController(ApplicationDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapear el DTO a la entidad users
            var user = UserMapper.MapRegisterUserDtoToUser(userDto);

            // Agregar el usuario a la base de datos
            _context.users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "Usuario registrado exitosamente." });
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto loginDto)
        {
            var existingUser = _context.users.FirstOrDefault(u => u.email == loginDto.Email);

            if (existingUser == null)
            {
                return Unauthorized(new { message = "Usuario no encontrado." });
            }

            // Verificar la contraseña encriptada
            string hashedPassword = PasswordHasher.HashPassword(loginDto.Password);

            if (existingUser.password != hashedPassword)
            {
                return Unauthorized(new { message = "Contraseña incorrecta." });
            }

            var token = _authService.GenerateJwtToken(existingUser);
            return Ok(new { token, rol = existingUser.rol });
        }

    }
}