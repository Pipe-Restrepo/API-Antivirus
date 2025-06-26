using System.Security.Cryptography;
using System.Text;
using Api_Antivirus.Config;
using Api_Antivirus.Models;

public class UserMapper
{
    public static users MapRegisterUserDtoToUser(RegisterUserDto userDto)
    {
        return new users
        {
            name = userDto.Name,
            email = userDto.Email,
            rol = userDto.Rol,
            password = PasswordHasher.HashPassword(userDto.Password),
        };
    }
}