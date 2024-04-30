using CleanArcMvc.API.DTO;
using CleanArcMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcMvc.API;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authenticate;

    public TokenController(IAuthenticate authenticate)
    {
        _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
    }

    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginDto userLogin)
    {
        var result = await _authenticate.Authenticate(userLogin.Email, userLogin.Password);

        if(result)
        {
            //return GenerateToken(userLogin);
            return Ok($"User {userLogin.Email} login successfully.");
        }
        
        else
        {
            ModelState.TryAddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }
    }

}
