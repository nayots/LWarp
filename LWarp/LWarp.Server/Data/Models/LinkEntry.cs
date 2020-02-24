using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace LWarp.Server.Data.Models
{
    public class LinkEntry
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string ShortId { get; set; }

        public string Url { get; set; }

        public DateTimeOffset Created { get; set; }

        public int Hits { get; set; }
    }
}