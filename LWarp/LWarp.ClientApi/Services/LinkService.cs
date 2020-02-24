using Grpc.Net.Client;
using LWarp.ClientApi.Common;
using LWarp.ClientApi.Models;
using LWarp.ClientApi.Services.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace LWarp.ClientApi.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILogger logger;
        private readonly GrpcConfig grpcConfig;

        public LinkService(ILogger<LinkService> logger, IOptions<GrpcConfig> config)
        {
            this.logger = logger;
            this.grpcConfig = config.Value;
        }

        public async Task<string> CreateShortLinkAsync(LinkData linkData)
        {
            var result = await this.GetClient().CreateLinkAsync(new GrpcClient.LinkCreateRequest()
            {
                Link = linkData.LinkValue
            });

            return result.Id;
        }

        public async Task<string> GetLinkByShortIdAsync(string shortId)
        {
            var result = await this.GetClient().GetLinkAsync(new GrpcClient.GetLinkRequest()
            {
                Id = shortId
            });

            return result.Link;
        }

        private LWarp.GrpcClient.Link.LinkClient GetClient()
        {
            var channel = GrpcChannel.ForAddress(this.grpcConfig.ServerAddress);

            return new GrpcClient.Link.LinkClient(channel);
        }
    }
}