using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace x_kom_simple_API.Entities
{
    public class Participant
    {
        [BsonElement("name")]
        public string Name { get; init; }

        [BsonElement("email")]
        public string Email { get; init; }
    }
}
