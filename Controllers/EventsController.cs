using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using x_kom_simple_API.Entities;
using x_kom_simple_API.Utilities;

namespace x_kom_simple_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMongoClient client;

        public EventsController (IMongoClient client)
        {
            this.client = client;
        }
        
        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            var collection = GetEventsCollection("XKOM", "Events");
            return collection.Find(s => true).ToList();
        }


        [HttpPost]
        public void PostEvent(Event e)
        {
            var collection = GetEventsCollection("XKOM", "Events");
            collection.InsertOne(e);

        }

        [HttpDelete]
        public void DeleteEvent(Event e)
        {
            var collection = GetEventsCollection("XKOM", "Events");
            var filter = Filters.getEventEaqualsFilter(e);
            collection.DeleteOne(filter);
        }

        private IMongoCollection<Event> GetEventsCollection(String databaseName, String collectionName)
        {
            var database = client.GetDatabase(databaseName);
            return database.GetCollection<Event>(collectionName);
        }


    }
}
