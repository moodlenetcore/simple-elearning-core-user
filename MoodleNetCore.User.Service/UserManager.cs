using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoodleNetCore.User.Service
{
    public interface IUserManager
    {
        IEnumerable<User> GetAllUsers();

        User GetUserByID(Guid id);

        IdentityResult Create(User user, string password);

        IdentityResult Update(User user);

        IdentityResult DeleteUserByID(Guid id);
    }

    public class UserManager : UserManager<User>, IUserManager
    {
        public UserManager(
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users.AsEnumerable();
        }

        public User GetUserByID(Guid id)
        {
            return FindByIdAsync(id.ToString()).Result;
        }

        public IdentityResult Create(User user, string password)
        {
            return CreateAsync(user, password).Result;
        }

        public IdentityResult Update(User user)
        {
            return UpdateAsync(user).Result;
        }

        public IdentityResult DeleteUserByID(Guid id)
        {
            User user = FindByIdAsync(id.ToString()).Result;

            return DeleteAsync(user).Result;
        }
    }
}
