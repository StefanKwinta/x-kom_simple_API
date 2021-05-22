using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace x_kom_simple_API.Entities
{
    public class UpdateData
    {
        [BsonElement("event")]
        public Event updateEvent { get; init; }

        [BsonElement("partcipant")]
        public Participant updateParticipant { get; init; }
    }
}
