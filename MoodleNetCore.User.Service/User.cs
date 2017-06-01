using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MoodleNetCore.User.Service.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MoodleNetCore.User.Service
{
    public class User : IdentityUser<Guid>
    {
    }

    public class MyUserStore : UserStore<User, Role, MoodleContext, Guid>, IUserStore<User>
    {
        public MyUserStore(MoodleContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
