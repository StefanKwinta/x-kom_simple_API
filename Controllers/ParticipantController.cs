using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Linq;
using x_kom_simple_API.Entities;
using x_kom_simple_API.Utilities;

namespace x_kom_simple_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IMongoClient client;

        public ParticipantController(IMongoClient client)
        {
            this.client = client;
        }

        [HttpPut]
        public ActionResult<Event> PostParticipant(UpdateData updateData)
        {
            if(!IsCorrectData(updateData))
            {
                return StatusCode(403);
            }

            Event ev = new Event();
            var collection = GetEventsCollection("XKOM", "Events");
            var filter = Filters.getEventEaqualsFilter(updateData.EventToUpdate);

            try
            {
                ev = collection.Find(filter).First();
            }
            catch(System.InvalidOperationException e)
            {
                return StatusCode(404);
            }

            var updated = ev.Participants;
            updated.Add(updateData.ParticpantToUpdate);

            if(updated.Count > 25)
            {
                return StatusCode(403);
            }

            var update = Builders<Event>.Update.Set(x => x.Participants, updated);
            collection.UpdateOne(filter, update);

            return StatusCode(200); 

        }

        private bool IsCorrectData(UpdateData updateData)
        {
   
            return !(updateData.ParticpantToUpdate.Email == null || updateData.ParticpantToUpdate.Name == null) 
                && updateData.ParticpantToUpdate.Email.Contains("@");
        }

        private IMongoCollection<Event> GetEventsCollection(String databaseName, String collectionName)
        {
            var database = client.GetDatabase(databaseName);
            return database.GetCollection<Event>(collectionName); 
        }

    }
}
