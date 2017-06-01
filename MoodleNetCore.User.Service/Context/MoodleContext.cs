using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MoodleNetCore.User.Service.Context
{
    public interface IMoodleContext
    {

    }

    public class MoodleContext : IdentityDbContext<User, Role, Guid>, IMoodleContext
    {
        public MoodleContext(DbContextOptions<MoodleContext> options) : base(options)
        {
            
        }      
        
    }
}
