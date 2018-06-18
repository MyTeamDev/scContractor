using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace scContractorApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Delete")]
    public class DeleteController : Controller
    {
        // GET: api/Delete
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Delete/5
        [HttpGet("{requestLink}", Name = "requestLink")]
        public string Get(string requestLink)
        {
            return "value";
        }
        
        // POST: api/Delete
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Delete/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int RequestLink)
        {

        }
    }
}
