using Grpc.Core;
using LWarp.GrpcServer;
using LWarp.Server.Contracts;
using Microsoft.Extensions.Logging;
using shortid;
using System;
using System.Threading.Tasks;

namespace LWarp.Server.Services
{
    public class LinkService : Link.LinkBase
    {
        private readonly ILogger logger;
        private readonly ILinksRepository repo;

        public LinkService(ILogger<LinkService> logger, ILinksRepository repo)
        {
            this.logger = logger;
            this.repo = repo;
        }

        public override async Task<LinkCreatedReply> CreateLink(LinkCreateRequest request, ServerCallContext context)
        {
            var entry = new Data.Models.LinkEntry()
            {
                ShortId = ShortId.Generate(true, false),
                Created = DateTimeOffset.UtcNow,
                Url = request.Link
            };
            await this.repo.Create(entry);
            this.logger.LogInformation($"Created new link entry with short id: {entry.ShortId}");
            return await Task.FromResult(new LinkCreatedReply() { Id = entry.ShortId });
        }

        public override async Task<LinkReply> GetLink(GetLinkRequest request, ServerCallContext context)
        {
            this.logger.LogInformation($"Getting link for short id: {request.Id}");
            var item = await this.repo.GetByShortId(request.Id);
            return new LinkReply() { Link = item.Url };
        }
    }
}