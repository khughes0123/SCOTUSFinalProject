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
        private CaseService CreateCaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CaseService(userId);
            return service;
        }

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
            if (!ModelState.IsValid) return View(model);

            var service = CreateCaseService();

            if (service.CreateCase(model))

            {
                TempData["SaveResult"] = "Case has been added to our database.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Case could not be added, please confirm all necessary information has been entered.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCaseService();
            var model = svc.GetCaseById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCaseService();
            var detail = service.GetCaseById(id);
            var model =
                new CaseEdit
                {
                    CaseId = detail.CaseId,
                    Summary = detail.Summary,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CaseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CaseId != id)
            {
                ModelState.AddModelError("", "Not a valid Case Id.");
                return View(model);
            }

            var service = CreateCaseService();

            if (service.UpdateCase(model, id))

            {
                TempData["SaveResult"] = "Case has been added to our database.";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Case could not be added, please confirm all necessary information has been entered.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCaseService();
            var model = svc.GetCaseById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCaseService();

            service.DeleteCase(id);

            TempData["SaveResult"] = "Case was successfully deleted";

            return RedirectToAction("Index");
        }
    }

}



