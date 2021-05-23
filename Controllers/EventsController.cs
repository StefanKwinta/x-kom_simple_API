using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using x_kom_simple_API.Entities;

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
        public IEnumerable<Event> Get()
        {
            var collection = getEventsCollection("XKOM", "Events");
            return collection.Find(s => true).ToList();
        }


        [HttpPost]
        public void PostEvent(Event e)
        {
            var collection = getEventsCollection("XKOM", "Events");
            collection.InsertOne(e);

        }

        [HttpDelete]
        public void DeleteEvent(Event e)
        {
            var collection = getEventsCollection("XKOM", "Events");
            collection.DeleteOne(x => e.Name == x.Name);
        }

        private IMongoCollection<Event> getEventsCollection(String databaseName, String collectionName)
        {
            var database = client.GetDatabase(databaseName);
            return database.GetCollection<Event>(collectionName);
        }


    }
}
