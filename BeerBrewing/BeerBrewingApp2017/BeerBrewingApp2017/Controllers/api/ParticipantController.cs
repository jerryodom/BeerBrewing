using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeerBrewingApp2017.Controllers.api
{
    [Authorize]
    public class ParticipantController : ApiController
    {
        // GET api/<controller>
        [Route("api/participant/getparticipant")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "participant1", "participant2" };
        }

        // GET api/<controller>/5
        [Route("api/participant/getparticipant/{id}")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        //[Route("getfindparticipant/{groupid}/{lastName}/{dateOfBirth}")]
        //public string GetFindParticipant(int groupId, string lastName, string dateOfBirth)
        //{
        //    return "value";
        //}
        //[Route("getfindparticipantbyidentity/{id}")]
        //public string GetFindParticipantByIdentity(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}