using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MoodleNetCore.User.Service.Context;
using System;

namespace MoodleNetCore.User.Service
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }

    public class MyRoleStore : RoleStore<Role, MoodleContext, Guid>, IRoleStore<Role>
    {
        public MyRoleStore(MoodleContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
