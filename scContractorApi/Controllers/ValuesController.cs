using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scContractorApi.BackEnd;
using Newtonsoft.Json;

namespace scContractorApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values/5
        [HttpGet("{token}")]
        public JsonResult GetLink(string token)
        {
            using (ListLinkContext db = new ListLinkContext())
            {
                var l = db.Links.Where(x => x.Token == token).Select(a=> new
                {
                    RequestCount = a.RequestCount,
                    RequestLink = a.RequestLink,
                    TargetLink = a.TargetLink,  
                    CreateDate = a.CreateDate
                }).ToList();
                return Json(l);
            }
        }

        // POST api/values
        [HttpPost]
        public void AddLink([FromBody]object value)
        {
            Link l = JsonConvert.DeserializeObject<Link>(value.ToString());
            using (ListLinkContext db = new ListLinkContext())
            {
                db.Links.Add(l);
                db.SaveChanges();
            }
        }
    }
}
