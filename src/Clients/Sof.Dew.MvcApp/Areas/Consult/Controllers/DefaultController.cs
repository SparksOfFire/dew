using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sof.Dew.MvcApp.Areas.Consult
{
    [Authorize]
    public class DefaultController : Controller
    {
        // GET: Consult/Default
        public ActionResult Index()
        {
            return View();
        }

        // GET: Consult/Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consult/Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consult/Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consult/Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Consult/Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consult/Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consult/Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
