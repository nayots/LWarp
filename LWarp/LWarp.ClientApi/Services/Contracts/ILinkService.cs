using LWarp.ClientApi.Models;
using System.Threading.Tasks;

namespace LWarp.ClientApi.Services.Contracts
{
    public interface ILinkService
    {
        Task<string> CreateShortLink(LinkData linkData);
    }
}