using LWarp.Server.Data.Models;
using MongoDB.Driver;

namespace LWarp.Server.Contracts
{
    public interface ILinksContext
    {
        IMongoCollection<LinkEntry> Links { get; }
    }
}