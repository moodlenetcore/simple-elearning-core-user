using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodleNetCore.User.Service;
using System;
using System.Collections.Generic;

namespace MoodleNetCore.User.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<Service.User> GetAllUsers()
        {
            return userManager.GetAllUsers();
        }

        [HttpGet("{id}", Name = "Get")]
        public Service.User Get(Guid id)
        {
            return userManager.GetUserByID(id);
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Service.User user)
        {
            IdentityResult ret = userManager.Update(user);

            if (ret.Succeeded)
                return Ok();

            return BadRequest(ret.Errors);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            IdentityResult ret = userManager.DeleteUserByID(id);

            if (ret.Succeeded)
                return Ok();

            return BadRequest(ret.Errors);
        }
    }
}
