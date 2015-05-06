using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NorthwindWebApi2.Controllers
{
    public class RegionController : ApiController
    {
        // GET: api/Region
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Region/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Region
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Region/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Region/5
        public void Delete(int id)
        {
        }
    }
}
