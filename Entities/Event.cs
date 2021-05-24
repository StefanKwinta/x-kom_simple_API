using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nest;
using System;
using System.Collections.Generic;

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

        [BsonElement("place")]
        public GeoLocation Place { get; init; }


        [BsonElement("partcipants")]
        public List<Participant> Participants
        {
            get;
            set;
        }

        public Event(ObjectId id, string name, string type, string description, DateTime startTime, DateTime endTime, GeoLocation place, List<Participant> participants)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Place = place;
            Participants = participants;
        }
        public Event()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Name == @event.Name &&
                   Type == @event.Type &&
                   Description == @event.Description &&
                   StartTime == @event.StartTime &&
                   EndTime == @event.EndTime &&
                   EqualityComparer<GeoLocation>.Default.Equals(Place, @event.Place);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Type, Description, StartTime, EndTime, Place);
        }
    }
}
