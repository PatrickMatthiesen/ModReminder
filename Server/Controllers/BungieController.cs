using BungieSharper.Client;
using Microsoft.AspNetCore.Mvc;
using BungieSharper.Entities.Destiny;
using BungieSharper.Entities.Destiny.Responses;

namespace ModReminder.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BungieController : ControllerBase
    {
        public readonly ILogger<BungieController> _logger;
        public readonly BungieApiClient _client;

        public BungieController(ILogger<BungieController> logger, BungieApiClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public async Task<DestinyPublicVendorsResponse> Get()
        {
            var components = new[] { DestinyComponentType.Vendors };
            return await _client.Api.Destiny2_GetPublicVendors(components);
        }


    }
}
