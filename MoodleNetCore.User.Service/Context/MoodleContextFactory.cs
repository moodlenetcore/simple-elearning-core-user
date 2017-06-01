using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MoodleNetCore.User.Service.Context
{
    public class MoodleContextFactory: IDbContextFactory<MoodleContext>
    {
        public MoodleContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoodleContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Moodle;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new MoodleContext(optionsBuilder.Options);

        }
    }
}
