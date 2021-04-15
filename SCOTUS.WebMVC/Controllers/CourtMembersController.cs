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
    public class CourtMembersController : Controller
    {
        public ActionResult Index()
        {
            // GET: CourtMembers
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourtMembersService(userId);
            var model = service.GetCourts();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourtMembersCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCourtMemberService();
            
            if (service.CreateCourtMembers(model))
            {
                TempData["SaveResult"] = "Court created.";
            return RedirectToAction("Index");
               
            }

            ModelState.AddModelError("", "Court not created, verify necessary information was entered");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateCourtMemberService();
            var model = svc.GetCourtById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCourtMemberService();
            var detail = service.GetCourtById(id);
            var model =
                new CourtMembersEdit
                {
                    CourtId = detail.CourtId,
                    JusticeOneChiefJustice = detail.JusticeOneChiefJustice,
                    JusticeTwo = detail.JusticeTwo,
                    JusticeThree = detail.JusticeThree,
                    JusticeFour = detail.JusticeFour,
                    JusticeFive = detail.JusticeFive,
                    JusticeSix = detail.JusticeSix,
                    JusticeSeven = detail.JusticeSeven,
                    JusticeEight = detail.JusticeEight,
                    JusticeNine = detail.JusticeNine,
                    JusticeTen = detail.JusticeTen
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourtMembersEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CourtId != id)
            {
                ModelState.AddModelError("", "Not a valid Court Id.");
                return View(model);
            }

            var service = CreateCourtMemberService();

            if (service.UpdateCourtMembers(model, id))

            {
                TempData["SaveResult"] = "Court has been added to our database.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Court could not be added, please confirm all necessary information has been entered.");

            return View(model);
        }

        private CourtMembersService CreateCourtMemberService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourtMembersService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCourtMemberService();
            var model = svc.GetCourtById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCourtMemberService();

            service.DeleteCourt(id);

            TempData["SaveResult"] = "Court was successfully deleted";

            return RedirectToAction("Index");
        }
    }
}
    
