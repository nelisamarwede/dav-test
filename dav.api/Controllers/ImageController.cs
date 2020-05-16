using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAV.Domain.EF.Commands;
using DAV.Domain.Entities;
using DAV.Domain.Queries.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dav.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageCommands commands;
        private readonly IQueryProvider<Image> imageQueryProvider;
        // GET: api/Image
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        public ActionResult<IEnumerable<Image>> Get(int userId)
        {
            return imageQueryProvider.Query.Where(i => i.userId == userId).ToList();
        }

        // POST: api/Image
        [HttpPost]
        public ActionResult<Image> Post([FromBody] Image image)
        {
            return commands.AddImage(image);
        }

        // PUT: api/Image/5
        //[HttpPut("{id}")]
        public ActionResult<bool> Put([FromBody] Image image)
        {
            return commands.UpdateImage(image);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete([FromBody] Image image)
        {
            commands.DeleteImage(image);
        }
    }
}
