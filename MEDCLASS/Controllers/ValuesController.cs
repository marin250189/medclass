using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MEDCLASS.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        [ActionName("Complex")]
        public IEnumerable<string> GetComplex()
        {

            return new string[] { "value1", "value2" };
        }
    }
}
