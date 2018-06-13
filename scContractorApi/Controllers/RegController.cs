using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using scContractorApi.BackEnd;

namespace scContractorApi.Controllers
{
    [Route("api/[controller]")]
    public class RegController : Controller
    {
        // GET api/reg
        [EnableCors("MyPolicy")]
        [HttpGet]
        public string Get()
        {     
            do
            {
                string res = BackEnd.Util.GenString(22);
                var json = new
                {
                    token = res
                };

                var result = JsonConvert.SerializeObject(json);

                using (ListLinkContext db = new ListLinkContext())
                {
                    List<Link> l = db.Links.Where(x => x.Token == res).ToList<Link>();
                    if (l.Count == 0) { return result.ToString(); }
                }
            }
            while (true);            
        }
    }
}

