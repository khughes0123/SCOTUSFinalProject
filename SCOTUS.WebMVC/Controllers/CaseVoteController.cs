using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCOTUS.WebMVC.Controllers
{
    public class CaseVoteController : Controller
    {
        // GET: CaseVote
        public ActionResult Index()
        {
            return View();
        }
    }
}