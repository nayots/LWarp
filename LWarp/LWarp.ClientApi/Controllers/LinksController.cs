using LWarp.ClientApi.Models;
using LWarp.ClientApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LWarp.ClientApi.Controllers
{
    [Route("api/[controller]")]
    public class LinksController : Controller
    {
        private readonly ILogger logger;
        private readonly ILinkService linkService;

        public LinksController(ILogger<LinksController> logger, ILinkService linkService)
        {
            this.logger = logger;
            this.linkService = linkService;
        }

        [HttpGet("{shortId}")]
        public async Task<IActionResult> Get([FromRoute]string shortId)
        {
            var result = await this.linkService.GetLinkByShortIdAsync(shortId);
            return this.Redirect(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LinkData linkData)
        {
            var result = await this.linkService.CreateShortLinkAsync(linkData);

            return this.Created(nameof(Get), new { id = result });
        }
    }
}