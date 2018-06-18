using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scContractorApi.BackEnd;

namespace scContractorApi.Controllers
{
    [Route("api/[controller]")]
    public class RedirectController : Controller
    {
        [HttpGet("{link}")]
        public RedirectResult Index(string link)
        {
            using (ListLinkContext db = new ListLinkContext())
            {
                Link links = db.Links.FirstOrDefault(x => x.RequestLink == link);
                links.RequestCount = links.RequestCount + 1;
                db.SaveChanges();
                return new RedirectResult(links.TargetLink);                
            }
        }
    }
}