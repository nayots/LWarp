using LWarp.ClientApi.Models;
using LWarp.ClientApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LWarp.ClientApi.Controllers
{
    [Route("api/[controller]")]
    public class LinksController : Controller
    {
        private readonly ILogger logger;
        private readonly ILinkService linkService;

        public LinksController(ILogger logger, ILinkService linkService)
        {
            this.logger = logger;
            this.linkService = linkService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LinkData linkData)
        {
            var result = await this.linkService.CreateShortLink(linkData);

            return this.Created(nameof(Get), new { id = result.Id });
        }
    }
}