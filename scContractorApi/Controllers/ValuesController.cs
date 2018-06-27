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
        public string GetAllOfLink(string token)
        {
            using (ListLinkContext db = new ListLinkContext())
            {
                var l = db.Links.Where(x => x.Token == token).Select(a => new
                {
                    RequestCount = a.RequestCount,
                    RequestLink = a.RequestLink,
                    TargetLink = a.TargetLink,
                    CreateDate = a.CreateDate
                });
                var result = JsonConvert.SerializeObject(l);
                return result;
            }
        }

        // POST api/values
        [HttpPost]
        public void AddLink(string link, string token)
        {
            Link lnk = new Link();
            lnk.Token = token;
            lnk.TargetLink = link;
            lnk.RequestLink = Util.GenString(6);
            lnk.RequestCount = 0;
            lnk.CreateDate = Util.GetCreateDate();

            using (ListLinkContext db = new ListLinkContext())
            {
                db.Links.Add(lnk);
                db.SaveChanges();
            }
            //return "Ok";
        }
    }
}
