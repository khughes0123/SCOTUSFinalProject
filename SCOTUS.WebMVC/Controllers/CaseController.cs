using SCOTUS.Models;
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
            var model = new CaseListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
}