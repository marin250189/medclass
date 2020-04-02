using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MEDCLASS.Controllers
{
    public class CompasController : ApiController
    {
        // GET api/compas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/compas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/compas
        public void Post([FromBody]string value)
        {
        }

        // PUT api/compas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/compas/5
        public void Delete(int id)
        {
        }
    }
}
