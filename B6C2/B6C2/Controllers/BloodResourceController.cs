﻿using B6C2.Models;
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
        // GET: bloodResource
        public ActionResult BloodResourceIndex()
        {
            return View(db.bloodResources.ToList());
        }

        // GET: bloodResource/Details/5
        public ActionResult DetailsBloodResource(int CenterID, int BloodID)
        {
            bloodResource a = db.bloodResources.Find(CenterID, BloodID);
            return View(a);
            
        }
       

        // GET: bloodResource/Create
        public ActionResult CreateBloodResource()
        {
            return View();
        }

        // POST: bloodResource/Create
        [HttpPost]
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
        public ActionResult EditBloodResource(int CenterID, int BloodID)
        {
            bloodResource a = db.bloodResources.Find(CenterID, BloodID);
            return View(a);
        }

        // POST: bloodResource/Edit/5
        [HttpPost]
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
        public ActionResult DeleteBloodResource(int CenterID, int BloodID)
        {
            bloodResource a = db.bloodResources.Find(CenterID, BloodID);
            return View(a);
        }

        // POST: bloodResource/Delete/5
        [HttpPost]
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