using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace x_kom_simple_API.Entities
{
    public record Event
    {
        [BsonId]
        public ObjectId Id { get; init; }

        [BsonElement("name")]
        public string Name { get; init; }

  
        [BsonElement("partcipants")]
        public List<Participant> Participants
        {
            get;
            set;
        }

        public Event(string Name)
        {
            this.Name = Name;
        }


    }
}
