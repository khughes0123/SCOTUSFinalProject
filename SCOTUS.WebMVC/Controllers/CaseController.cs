using Microsoft.AspNet.Identity;
using SCOTUS.Models;
using SCOTUS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCOTUS.WebMVC.Controllers
{
    [Authorize]
    public class CaseController : Controller
    {
        // GET: Case
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CaseService(userId);
            var model = service.GetCases();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CaseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CaseService(userId);

            service.CreateCase(model);

            return RedirectToAction("Index");
        }
    }
}