using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoodleNetCore.User.Api.Models;
using MoodleNetCore.User.Service;

namespace MoodleNetCore.User.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;
        private readonly ILoginManager loginManager;
        private readonly ILogger logger;

        public AccountController(IUserManager userManager, ILoginManager loginManager, ILoggerFactory loggerFactory)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Service.User user = new Service.User { UserName = model.Email, Email = model.Email };
                IdentityResult result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    loginManager.Login(user, isPersistent: false);
                    logger.LogInformation(3, "User created a new account with password.");
                    return Ok();
                }
                AddErrors(result);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = loginManager.Login(model.Email, model.Password, model.RememberMe);
                if (result.Succeeded)
                {
                    logger.LogInformation(1, "User logged in.");
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid login attempt.");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Logout()
        {
            loginManager.Logout();
            logger.LogInformation(4, "User logged out.");
            return Ok();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
