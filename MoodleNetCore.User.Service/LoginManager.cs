using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MoodleNetCore.User.Service
{
    public interface ILoginManager
    {
        SignInResult Login(string username, string password, bool rememberMe);

        void Login(User user, bool isPersistent);

        void Logout();
    }

    public class LoginManager : SignInManager<User>, ILoginManager
    {
        public LoginManager(UserManager<User> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<User>> logger) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
        }

        public SignInResult Login(string username, string password, bool rememberMe)
        {
            return PasswordSignInAsync(username, password, rememberMe, false).Result;
        }

        public void Login(User user, bool isPersistent)
        {
            SignInAsync(user, isPersistent).Wait();
        }

        public void Logout()
        {
            SignOutAsync().Wait();
        }
    }
}
