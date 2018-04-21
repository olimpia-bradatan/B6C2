using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{

    public class MedicController : Controller
    {
        ISSContext db = new ISSContext();

        // GET: Donor
        public ActionResult MedicIndex()
        {
            return View(db.Medics.ToList());
        }

        // GET: Donor/Details/5
        public ActionResult MedicDetails(int id)
        {
            return View(db.Medics.Find(id));
        }

        // GET: Donor/Create
        public ActionResult MedicCreate()
        {
            return View();
        }

        // POST: Donor/Create
        [HttpPost]
        public ActionResult MedicCreate(Medic medic)
        {
            if (ModelState.IsValid)
            {
               MedicComparer cmp = new MedicComparer();
                int ok = 1;
                if (db.Medics.Count() > 0)
                {
                    foreach (var d in db.Medics)
                        if (cmp.Equals(d, medic))
                            ok = 0;
                }
                if (ok == 1)
                {
                    TempData["Success"] = "Medic successfully added!";
                    db.Medics.Add(medic);
                    db.SaveChanges();
                    return RedirectToAction("MedicIndex");
                }
                else
                {
                    TempData["Warning"] = "Medic already exists! Try add another one!";
                    return RedirectToAction("MedicCreate");
                }
            }
            return View();
        }

        // GET: Donor/Edit/5
        public ActionResult MedicEdit(int id)
        {
            return View(db.Medics.Find(id));
        }

        // POST: Donor/Edit/5
        [HttpPost]
        public ActionResult MedicEdit(int id, Medic medic)
        {
            try
            {
                db.Entry(medic).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Medic successfully updated!";
                return RedirectToAction("MedicIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donor/Delete/5
        public ActionResult MedicDelete(int id)
        {
            return View(db.Medics.Find(id));
        }

        // POST: Donor/Delete/5
        [HttpPost]
        public ActionResult MedicDelete(int id, Medic medic)
        {
            try
            {
                db.Medics.Remove(db.Medics.Find(id));
                db.SaveChanges();
                TempData["Success"] = "Medic successfully deleted!";
                return RedirectToAction("MedicIndex");
            }
            catch
            {
                return View();
            }
        }

    }
}
