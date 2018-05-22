using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class DonationCenterController : Controller
    {
        ISSContext db = new ISSContext();
        // GET: DonationCenter
        public ActionResult DonationCenterIndex()
        {
            return View(db.donationCenters.ToList());
        }

        // GET: DonationCenter/Details/5
        public ActionResult DonationCenterDetails(int id)
        {
            return View(db.donationCenters.Find(id));
        }

        // GET: DonationCenter/Create
        [Authorize(Roles = "Admin")]
        public ActionResult DonationCenterCreate()
        {
            return View();
        }

        // POST: DonationCenter/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DonationCenterCreate(donationCenter donationCenter)
        {
            if (ModelState.IsValid)
            {
                DonationCenterComparer cmp = new DonationCenterComparer();
                int ok = 1;
                if (db.donationCenters.Count() > 0)
                {
                    foreach (var d in db.donationCenters)
                        if (cmp.Equals(d, donationCenter))
                            ok = 0;
                }
                if (ok == 1)
                {
                    TempData["Success"] = "Donation Center successfully added!";
                    db.donationCenters.Add(donationCenter);
                    db.SaveChanges();
                    return RedirectToAction("DonationCenterIndex");
                }
                else
                {
                    TempData["Warning"] = "Donation Center already exists! Try add another one!";
                    return RedirectToAction("DonationCenterCreate");
                }
            }
            return View();
        }

        // GET: DonationCenter/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult DonationCenterEdit(int id)
        {
            return View(db.donationCenters.Find(id));
        }

        // POST: DonationCenter/Edit/5
        [HttpPost]
        public ActionResult DonationCenterEdit(int id, donationCenter donationCenter)
        {
            try
            {
                db.Entry(donationCenter).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Donation Center successfully updated!";
                return RedirectToAction("DonationCenterIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: DonationCenter/Delete/5
        public ActionResult DonationCenterDelete(int id)
        {
            return View(db.donationCenters.Find(id));
        }

        // POST: DonationCenter/Delete/5
        [HttpPost]
        public ActionResult DonationCenterDelete(int id, donationCenter donationCenter)
        {
            try
            {
                db.donationCenters.Remove(db.donationCenters.Find(id));
                db.SaveChanges();
                TempData["Success"] = "Donation Center successfully deleted!";
                return RedirectToAction("DonationCenterIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
