using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace MoodleNetCore.User.Service
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
