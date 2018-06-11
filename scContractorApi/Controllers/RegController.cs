using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace scContractorApi.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class RegController : Controller
    {
        // GET api/reg
        [HttpGet]
        public string Get()
        {
            string res = BackEnd.Util.GenString(22);
            var json = new {
                token = res
        };
            var r = JsonConvert.SerializeObject(json);
            return r.ToString();
        }
    }
}

