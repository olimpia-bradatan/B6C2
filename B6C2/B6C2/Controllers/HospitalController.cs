using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class HospitalController : Controller
    {
        ISSContext db = new ISSContext();

        // GET: Donor
        public ActionResult HospitalIndex()
        {
            return View(db.Hospitals.ToList());
        }

        // GET: Donor/Details/5
        public ActionResult HospitalDetails(int id)
        {
            return View(db.Hospitals.Find(id));
        }

        // GET: Donor/Create
        [Authorize(Roles = "Admin")]
        public ActionResult HospitalCreate()
        {
            return View();
        }

        // POST: Donor/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult HospitalCreate( Hospital hospital )
        {
            if (ModelState.IsValid)
            {
                HospitalComparer cmp = new HospitalComparer();
                int ok = 1;
                if (db.Medics.Count() > 0)
                {
                    foreach (var d in db.Hospitals)
                        if (cmp.Equals(d, hospital))
                            ok = 0;
                }
                if (ok == 1)
                {
                    TempData["Success"] = "Hospital successfully added!";
                    db.Hospitals.Add(hospital);
                    db.SaveChanges();
                    return RedirectToAction("HospitalIndex");
                }
                else
                {
                    TempData["Warning"] = "Hospital already exists! Try add another one!";
                    return RedirectToAction("HospitalCreate");
                }
            }
            return View();
        }

        // GET: Donor/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult HospitalEdit(int id)
        {
            return View(db.Hospitals.Find(id));
        }

        // POST: Donor/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult HospitalEdit(int id, Hospital hospital)
        {
            try
            {
                db.Entry(hospital).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Hospital successfully updated!";
                return RedirectToAction("HospitalIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donor/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult HospitalDelete(int id)
        {
            return View(db.Hospitals.Find(id));
        }

        // POST: Donor/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult HospitalDelete(int id, Hospital hospital)
        {
            try
            {
                db.Hospitals.Remove(db.Hospitals.Find(id));
                db.SaveChanges();
                TempData["Success"] = "Hospital successfully deleted!";
                return RedirectToAction("HospitalIndex");
            }
            catch
            {
                return View();
            }
        }

    }
}
