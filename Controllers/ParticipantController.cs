using Microsoft.AspNetCore.Mvc;
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
    public class ParticipantController : ControllerBase
    {
        private IMongoClient client;

        public ParticipantController(IMongoClient client)
        {
            this.client = client;
        }

        [HttpPut]
        public ActionResult<Event> PostParticipant(UpdateData updateData)
        {
            if(!isCorrectData(updateData))
            {
                return StatusCode(403);
            }
            var database = client.GetDatabase("XKOM");
            var collection = database.GetCollection<Event>("Events");
            var ev = collection.Find(x => x.Name == updateData.updateEvent.Name).First();
            var updated = ev.Participants;
            updated.Add(updateData.updateParticipant);

            if(updated.Count > 25)
            {
                return StatusCode(403);
            }

            var filter = Builders<Event>.Filter.Eq("name", ev.Name);
            var update = Builders<Event>.Update.Set(x => x.Participants, updated);

            collection.UpdateOne(filter, update);

            return StatusCode(200); 

        }

        private bool isCorrectData(UpdateData updateData)
        {
   
            return !(updateData.updateParticipant.Email == null || updateData.updateParticipant.Name == null) 
                && updateData.updateParticipant.Email.Contains("@");
        }
    }
}
