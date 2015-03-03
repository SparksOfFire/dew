using Sof;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace Sof.Dew.MvcApp.Areas.Demo.Controllers
{
    public class CRUDController : Controller
    {
        // GET: Demo/CRUD
        //public ActionResult Index()
        //{
        //    //var patientManager = ServiceFactory.GetService<Services.PatientManager>();
        //    //var patients = patientManager.GetPatients(predicate: p => true);
        //    //if (patients.Count == 0)
        //    //{
        //    //    patients.Add(new Sof.Dew.Models.Patient { PatientId = "1", PatientName = "p1", Sex = Dew.Models.Enums.Sex.Male });
        //    //    patients.Add(new Sof.Dew.Models.Patient { PatientId = "2", PatientName = "p2", Sex = Dew.Models.Enums.Sex.Female });
        //    //    patients.Add(new Sof.Dew.Models.Patient { PatientId = "3", PatientName = "p3", Sex = Dew.Models.Enums.Sex.None });

        //    //    patientManager.AddPatients(patients);
        //    //}
        //    return View(patients.ToPagedList(1, 20));
        //}

        // GET: Demo/CRUD/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demo/CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demo/CRUD/Create
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

        // GET: Demo/CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demo/CRUD/Edit/5
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

        // GET: Demo/CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demo/CRUD/Delete/5
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
