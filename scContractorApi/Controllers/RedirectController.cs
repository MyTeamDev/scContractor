using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scContractorApi.BackEnd;

namespace scContractorApi.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult Index(string link)
        {
            using (ListLinkContext db = new ListLinkContext())
            {
                List<Link> links = db.Links.Where(x => x.RequestLink == link).Select(a => new Link
                {
                    Id = a.Id,
                    Token = a.Token,
                    RequestCount = a.RequestCount,
                    RequestLink = a.RequestLink,
                    TargetLink = a.TargetLink,
                    CreateDate = a.CreateDate
                }).ToList();
                Link l = links[0];
                l.RequestCount = l.RequestCount + 1;
                db.SaveChanges();
                return Content("<script>window.location = '"+l.TargetLink+"';</script>"); ;
            }
        }
    }
}