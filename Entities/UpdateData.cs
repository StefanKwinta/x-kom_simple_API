using MongoDB.Bson.Serialization.Attributes;

namespace x_kom_simple_API.Entities
{
    public class UpdateData
    {
        
        [BsonElement("event")]
        public Event EventToUpdate { get; init; }

        [BsonElement("partcipant")]
        public Participant ParticpantToUpdate { get; init; }

        public UpdateData(Event eventToUpdate, Participant particpantToUpdate)
        {
            EventToUpdate = eventToUpdate;
            ParticpantToUpdate = particpantToUpdate;
        }

    }
}
