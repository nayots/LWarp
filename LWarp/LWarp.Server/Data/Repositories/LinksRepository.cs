using LWarp.Server.Contracts;
using LWarp.Server.Data.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace LWarp.Server.Data.Repositories
{
    public class LinksRepository : ILinksRepository
    {
        private readonly ILogger logger;
        private readonly ILinksContext context;

        public LinksRepository(ILogger<LinksRepository> logger, ILinksContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task Create(LinkEntry entry)
        {
            this.logger.LogInformation($"Inserting entry with short id: {entry.ShortId}");
            await this.context.Links.InsertOneAsync(entry).ConfigureAwait(false);
        }

        public async Task<LinkEntry> GetByShortId(string shortId)
        {
            this.logger.LogInformation($"Getting data for short id: {shortId}");
            FilterDefinition<LinkEntry> filter = Builders<LinkEntry>.Filter.Eq(m => m.ShortId, shortId);
            var results = await this.context.Links.Find(filter).ToListAsync().ConfigureAwait(false);
            return results.FirstOrDefault();
        }
    }
}