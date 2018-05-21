using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class BloodResourceController : Controller
    {
        ISSContext db = new ISSContext();

        private List<SelectListItem> GetDonationCentersList()
        {
            return db.donationCenters
              .Select(e => new SelectListItem
              {
                  Value = e.idCenter.ToString(),
                  Text = e.name
              })
             .ToList();
        }

        // GET: bloodResource
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult BloodResourceIndex()
        {
            return View(db.bloodResources.ToList());
        }

        // GET: bloodResource/Details/5
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult DetailsBloodResource(int CenterID, int BloodID)
        {
            bloodResource a = db.bloodResources.Find(CenterID, BloodID);
            return View(a);
            
        }


        // GET: bloodResource/Create
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult CreateBloodResource()
        {
            ViewBag.DonationCenters = new SelectList(GetDonationCentersList(), "Value", "Text");
            return View();
        }

        // POST: bloodResource/Create
        [HttpPost]
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult CreateBloodResource(bloodResource bloodresource)
        {
            if(ModelState.IsValid)
            {
                BloodResourceComparer cmp = new BloodResourceComparer();
                int ok = 1;
                if (db.bloodResources.Count() > 0)
                {
                    foreach (var d in db.bloodResources)
                        if (cmp.Equals(d, bloodresource))
                            ok = 0;
                }
                if (ok == 1)
                {
                    TempData["Success"] = "Blood resource successfully added!";
                    db.bloodResources.Add(bloodresource);
                    db.SaveChanges();
                    return RedirectToAction("BloodResourceIndex");
                }
                else
                {
                    TempData["Warning"] = "Blood resource already exists! Try add another one!";
                    return RedirectToAction("CreateBloodRescource");
                }
            }
            return View();
        }

        // GET: bloodResource/Edit/5
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult EditBloodResource(int CenterID, int BloodID)
        {
            bloodResource a = db.bloodResources.Find(CenterID, BloodID);
            return View(a);
        }

        // POST: bloodResource/Edit/5
        [HttpPost]
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult EditBloodResource(int CenterID, int BloodID, bloodResource br)
        {
            try
            {
                db.Entry(br).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Blood resource successfully updated!";
                return RedirectToAction("BloodResourceIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: bloodResource/Delete/5
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult DeleteBloodResource(int CenterID, int BloodID)
        {
            bloodResource a = db.bloodResources.Find(CenterID, BloodID);
            return View(a);
        }

        // POST: bloodResource/Delete/5
        [HttpPost]
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult DeleteBloodResource(int CenterID, int BloodID, bloodResource br)
        {
            try
            {
                db.bloodResources.Remove(db.bloodResources.Find( CenterID,  BloodID));
                db.SaveChanges();
                TempData["Success"] = "Blood resource successfully deleted!";
                return RedirectToAction("BloodResourceIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
