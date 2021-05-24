using MongoDB.Driver;
using x_kom_simple_API.Entities;

namespace x_kom_simple_API.Utilities
{
    public static class Filters
    {
        public static FilterDefinition<Event> getEventEaqualsFilter(Event e)
        {
            return Builders<Event>.Filter.Eq("name", e.Name)
            & Builders<Event>.Filter.Eq("type", e.Type)
            & Builders<Event>.Filter.Eq("description", e.Description)
            & Builders<Event>.Filter.Eq("start_time", e.StartTime)
            & Builders<Event>.Filter.Eq("end_time", e.EndTime)
            & Builders<Event>.Filter.Eq("place", e.Place);
        }
    }
}
