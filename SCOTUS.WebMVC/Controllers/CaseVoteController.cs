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
    public class CaseVoteController : Controller
    {

        private CaseVoteService CreateCaseVoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CaseVoteService(userId);
            return service;
        }

        // GET: CaseVote
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CaseVoteService(userId);
            var model = service.GetCaseVotes();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            CaseVoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCaseVoteService();

            if (service.CreateCaseVote(model))

            {
                TempData["SaveResult"] = "Case vote has been added to our database.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Case vote could not be added, please confirm all necessary information has been entered.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCaseVoteService();
            var model = svc.GetCaseVoteById(id);

            return View(model);
        }
    }
}