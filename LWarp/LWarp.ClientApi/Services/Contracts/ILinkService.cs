using LWarp.ClientApi.Models;
using System.Threading.Tasks;

namespace LWarp.ClientApi.Services.Contracts
{
    public interface ILinkService
    {
        Task<GrpcClient.LinkCreatedReply> CreateShortLink(LinkData linkData);
    }
}