using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace B6C2.Controllers
{
    public class DonorController : Controller
    {
        ISSContext db = new ISSContext();

        // GET: Donor
        public ActionResult DonorIndex()
        {
            return View(db.Donors.ToList());
        }

        // GET: Donor/Details/5
        public ActionResult DonorDetails(int id)
        {
            return View(db.Donors.Find(id));
        }

        // GET: Donor/Create
        public ActionResult DonorCreate()
        {
            return View();
        }

        // POST: Donor/Create
        [HttpPost]
        public ActionResult DonorCreate(Donor donor)
        {
            if (ModelState.IsValid)
            {
                DonorComparer cmp = new DonorComparer();
                int ok = 1;
                if (db.Donors.Count() > 0)
                {
                    foreach (var d in db.Donors)
                        if (cmp.Equals(d, donor))
                            ok = 0;
                }
                if (ok == 1)
                {
                    TempData["Success"] = "Donor successfully added!";
                    db.Donors.Add(donor);
                    db.SaveChanges();
                    return RedirectToAction("DonorIndex");
                }
                else
                {
                    TempData["Warning"] = "Donor already exists! Try add another one!";
                    return RedirectToAction("DonorCreate");
                }
            }
            return View();
        }

        // GET: Donor/Edit/5
        public ActionResult DonorEdit(int id)
        {
            return View(db.Donors.Find(id));
        }

        // POST: Donor/Edit/5
        [HttpPost]
        public ActionResult DonorEdit(int id, Donor donor)
        {
            try
            {
                db.Entry(donor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Donor successfully updated!";
                return RedirectToAction("DonorIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donor/Delete/5
        public ActionResult DonorDelete(int id)
        {
            return View(db.Donors.Find(id));
        }

        // POST: Donor/Delete/5
        [HttpPost]
        public ActionResult DonorDelete(int id, Donor donor)
        {
            try
            {
                db.Donors.Remove(db.Donors.Find(id));
                db.SaveChanges();
                TempData["Success"] = "Donor successfully deleted!";
                return RedirectToAction("DonorIndex");
            }
            catch
            {
                return View();
            }
        }

    }
}
