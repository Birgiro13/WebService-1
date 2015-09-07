using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    [Authorize]
    [RoutePrefix("api/value")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
