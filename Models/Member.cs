using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElaApi.Models
{
    public class Member
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string DiscordId { get; set; }

        public int TotalPoints { get; set; }

        public int CurrentPoints { get; set; }
    }
}