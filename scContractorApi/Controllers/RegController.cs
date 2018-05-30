using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace scContractorApi.Controllers
{
    [Route("api/[controller]")]
    public class RegController : Controller
    {
        // GET api/reg
        [HttpGet]
        public string Get()
        {
            return BackEnd.Util.GenString(22);
        }
    }
}

