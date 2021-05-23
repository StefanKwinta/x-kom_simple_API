using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace x_kom_simple_API.Entities
{
    public class Event
    {
        [BsonId]
        public ObjectId Id { get; init; }

        [BsonElement("name")]
        public string Name { get; init; }

        [BsonElement("type")]
        public string Type { get; init; }

        [BsonElement("description")]
        public string Description { get; init; }

        [BsonElement("start_time")]
        public DateTime StartTime { get; init; }

        [BsonElement("end_time")]
        public DateTime EndTime { get; init; }


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

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id.Equals(@event.Id) &&
                   Name == @event.Name &&
                   Type == @event.Type &&
                   Description == @event.Description &&
                   StartTime == @event.StartTime &&
                   EndTime == @event.EndTime &&
                   EqualityComparer<List<Participant>>.Default.Equals(Participants, @event.Participants);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Type, Description, StartTime, EndTime, Participants);
        }
    }
}
