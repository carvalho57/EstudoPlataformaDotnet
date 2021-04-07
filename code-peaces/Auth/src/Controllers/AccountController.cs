using ApiAuth.Models;
using ApiAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("accounts")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountHandler) {
            _accountService = accountHandler;        
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginModel login) {
            var result = _accountService.Login(login);

            if(!result.Sucess)
                return NotFound(result.Data);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public ActionResult Create(UserModel model) {
            var result =  _accountService.CreateUser(model);
            
            if(!result.Sucess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}