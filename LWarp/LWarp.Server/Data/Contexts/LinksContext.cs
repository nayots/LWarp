using LWarp.Server.Contracts;
using LWarp.Server.Data.Configs;
using LWarp.Server.Data.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LWarp.Server.Data.Contexts
{
    public class LinksContext : ILinksContext
    {
        private readonly IMongoDatabase db;
        private readonly ILogger logger;

        public LinksContext(ILogger<LinksContext> logger, IOptions<MongoConfig> mongoConfig)
        {
            this.logger = logger;

            var client = new MongoClient(mongoConfig.Value.ConnectionString);

            this.db = client.GetDatabase(mongoConfig.Value.Database);
        }

        public IMongoCollection<LinkEntry> Links => this.db.GetCollection<LinkEntry>("Links");
    }
}