using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArcMvc.API.DTO;
using CleanArcMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArcMvc.API;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authenticate;
    private readonly IConfiguration _configuration;

    public TokenController(IAuthenticate authenticate, IConfiguration configuration)
    {
        _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
        _configuration = configuration;
    }

    [HttpPost("CreateUser")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult> CreateUser([FromBody] LoginDto loginDto)
    {
        var result = await _authenticate.RegisterUser(loginDto.Email, loginDto.Password);

        if(result)
            return Ok($"User {loginDto.Email} was created successfuly.");
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
            return BadRequest(ModelState);
        }
    }

    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginDto userLogin)
    {
        var result = await _authenticate.Authenticate(userLogin.Email, userLogin.Password);

        if(result)
        {
            return GenerateToken(userLogin);
            //return Ok($"User {userLogin.Email} login successfully.");
        }
        
        else
        {
            ModelState.TryAddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }
    }

    private UserToken GenerateToken(LoginDto login)
    {
        // declaracao do user
        var claimsSet = new[]
        {
            new Claim("email", login.Email),
            new Claim("meuvalor", "oqvcquiser"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        // gerar chave privada para assinar token
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        // gerar a assinatura digital
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        // definir a expiracao
        var expiration = DateTime.UtcNow.AddMinutes(10);

        // gerar o token
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claimsSet,
            expires: expiration,
            signingCredentials: credentials
        );

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration  
        };
    }
}
