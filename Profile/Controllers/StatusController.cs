using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Profile.Entityframework.EF;
using Profile.Mock;
using EF = Profile.Entityframework.EF;

namespace Profile.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly INotificationService notify;

        public StatusController(INotificationService notify)
        {
            this.notify = notify;
        }

        // GET: api/Profile
        [HttpGet("healthz")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}