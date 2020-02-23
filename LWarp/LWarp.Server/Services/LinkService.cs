using Grpc.Core;
using LWarp.GrpcServer;
using shortid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWarp.Server.Services
{
    public class LinkService: Link.LinkBase
    {
        public override async Task<LinkCreatedReply> CreateLink(LinkCreateRequest request, ServerCallContext context)
        {
            return await Task.FromResult(new LinkCreatedReply() { Id = ShortId.Generate(true, false) });
        }
    }
}
