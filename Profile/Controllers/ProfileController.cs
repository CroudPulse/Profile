using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profile.Entityframework.EF;
using EF = Profile.Entityframework.EF;


namespace Profile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly EF.CroudPulseDbContext context;

        public ProfileController(CroudPulseDbContext context)
        {
            this.context = context;
        }


        // GET: api/Profile
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Profile/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profile
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EF.Profile profile)
        {
            profile.ProfileId = Guid.NewGuid().ToString();
            this.context.Profile.Add(profile);
            await this.context.SaveChangesAsync();
            
            return Ok(profile);
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
