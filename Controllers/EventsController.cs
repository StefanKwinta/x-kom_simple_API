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
        private IMongoCollection<Event> _events;
        private IMongoClient client;

        public EventsController (IMongoClient client)
        {
            this.client = client;
        }
        
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            var database = client.GetDatabase("XKOM");
            var collection = database.GetCollection<Event>("Events");
            return collection.Find(s => true).ToList();
        }


        [HttpPost]
        public void PostEvent(Event e)
        {
            var database = client.GetDatabase("XKOM");
            var collection = database.GetCollection<Event>("Events");
            collection.InsertOne(e);

        }


    }
}
