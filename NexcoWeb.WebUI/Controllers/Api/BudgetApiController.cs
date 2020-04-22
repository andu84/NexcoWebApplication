using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace NexcoWeb.WebUI.Controllers.Api
{
    public class BudgetApiController : ApiController
    {
        // GET api/Sample
        public IHttpActionResult Get()
        {
            return Ok("It works!");
        }
        // GET api/Sample/{id}
        public IHttpActionResult Get(string id)
        {
            return Ok("It works! Your id is " + id);
        }

        // POST api/Sample
        public void Post([FromBody]string value)
        {
            throw new NotSupportedException();
        }

        // PUT api/Sample/{id}
        public void Put(string id, [FromBody]string value)
        {
            throw new NotSupportedException();
        }

        // DELETE api/Sample/{id}
        public void Delete(string id)
        {
            throw new NotSupportedException();
        }

        [HttpGet]
        [Route("api/Sample/Custom")]
        public IHttpActionResult Custom()
        {
            // sample custom action method using attribute-based routing
            // TODO: my code here
            throw new NotImplementedException();
        }
    }
}
