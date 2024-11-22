using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiColegio.Web.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class ApiKeyController : ControllerBase
//{
//    private readonly JwtSettings _jwtSettings;

//    public ApiKeyController(IOptions<JwtSettings> jwtSettings)
//    {
//        _jwtSettings = jwtSettings.Value;
//    }

//    [HttpGet("token")]
//    public IActionResult GetToken()
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();
//        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

//        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
//        {
//            SigningCredentials = new SigningCredentials(
//                new SymmetricSecurityKey(key),
//                SecurityAlgorithms.HmacSha256Signature),
//            Expires = DateTime.UtcNow.AddDays(_jwtSettings.ExpiryInDays),
//            // Aquí puedes añadir claims u otras configuraciones
//        });

//        return Ok(new { token = tokenHandler.WriteToken(token) });
//    }
//}
