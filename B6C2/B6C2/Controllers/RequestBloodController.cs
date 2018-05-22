using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class RequestBloodController : Controller
    {
        ISSContext db = new ISSContext();

        private System.Collections.Generic.List<SelectListItem> GetDonationCentersList()
        {
            return db.donationCenters
              .Select(e => new SelectListItem
              {
                  Value = e.idCenter.ToString(),
                  Text = e.name
              })
             .ToList();
        }

        private System.Collections.Generic.List<SelectListItem> GetHospitalsList()
        {
            return db.Hospitals
              .Select(e => new SelectListItem
              {
                  Value = e.idHospital.ToString(),
                  Text = e.name
              })
             .ToList();
        }
        // GET: ReguestBlood/Create
        [Authorize(Roles = "Medic")]
        public ActionResult RequestBloodCreate()
        {
            ViewBag.Hospitals = new SelectList(GetHospitalsList(), "Value", "Text");
            ViewBag.donationCenters = new SelectList(GetDonationCentersList(), "Value", "Text");
            return View();
        }

        // POST: RequestBlood/Create
        [HttpPost]
        [Authorize(Roles = "Medic")]
        public ActionResult RequestBloodCreate(RequestBlood req)
        {

            if (ModelState.IsValid)
            {

                Transaction t = new Transaction();
                t.idBlood = req.idBlood;
                bloodResource br = db.bloodResources.Find(req.idCenter, req.idBlood);
                if (br.quantity >= req.quantity)
                {
                    t.status = "Pregatire";
                    br.quantity = br.quantity - t.quantity;
                    db.Entry(br).State = System.Data.Entity.EntityState.Modified;
                }
                else
                    t.status = "Prelevare";

                t.idCenter = req.idCenter;
                t.idHospital = req.idHospital;
                t.quantity = req.quantity;
                
                db.Transactions.Add(t);
                db.SaveChanges();
                TempData["Success"] = "Request blood submitted!";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}

