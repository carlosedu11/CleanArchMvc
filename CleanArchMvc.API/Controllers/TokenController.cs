using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
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
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authenticate.Authenticate(loginModel.Email, loginModel.Password);

            if(result)
            {
                return GenerateToken(loginModel);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return BadRequest(ModelState);
            }

        }

    }
}
