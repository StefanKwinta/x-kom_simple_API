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
        
        public Participant(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
