using LWarp.Server.Data.Models;
using System.Threading.Tasks;

namespace LWarp.Server.Contracts
{
    public interface ILinksRepository
    {
        Task Create(LinkEntry entry);

        Task<LinkEntry> GetByShortId(string shortId);
    }
}