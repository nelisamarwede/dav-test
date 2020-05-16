using System.Collections.Generic;
using System.Linq;
using DAV.Domain.EF.Commands;
using DAV.Domain.Entities;
using DAV.Domain.Queries.Providers;
using Microsoft.AspNetCore.Mvc;

namespace dav.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserCommands commands;
        private readonly IQueryProvider<User> userQueryProvider;
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(string username, string password)
        {
            var user = userQueryProvider.Query.Where(i => i.username == username && i.password == password).FirstOrDefault();

            if (user!=null) return user;

            return null;
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return commands.AddUser(user);
        }

        // PUT: api/User/5
        //[HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] User user)
        {
            return commands.UpdateUser(user);
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        public void Delete([FromBody] User user)
        {
            commands.DeleteUser(user);
        }
    }
}
