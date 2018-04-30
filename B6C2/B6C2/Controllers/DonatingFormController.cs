using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class DonatingFormController : Controller
    {
        ISSContext db = new ISSContext();
        // GET: DonatingForm
        public ActionResult Index()
        {
            return View();
        }

        // GET: DonatingForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DonatingForm/Create
        public ActionResult CreateDonatingForm()
        {
            return View();
        }

        // POST: DonatingForm/Create
        [HttpPost]
        public ActionResult CreateDonatingForm(DonatingForm donatingForm)
        {
                int age = donatingForm.age;
                int weight = donatingForm.weight;
                int pulse = donatingForm.pulse;
                Boolean pregnancy = donatingForm.womanProblems;
                Boolean drinking = donatingForm.drink;
                Boolean intervention = donatingForm.intervention;
                Boolean affections = donatingForm.affections;
                if (age >= 18 && age <= 60 && weight >= 50 && pulse >= 60 && pulse <= 100 && !pregnancy && !drinking && !intervention && !affections)
                {
                    donorTransaction d = new donorTransaction();
                    d.cnpDonor = donatingForm.cnp;
                    d.idCenter = 1;
                    d.status = "Prelevare";
                    db.donorTransactions.Add(d);
                    db.SaveChanges();
                    TempData["Success"] = "Your request for donating blood has been submitted!";
                    return RedirectToAction("DonationCenterIndex", "DonationCenter");
                }
                TempData["ConditionsNotMet"] = "Sorry, the conditions to donate cannot be applied in your case!";
                return RedirectToAction("DonationCenterIndex", "DonationCenter");
            
        }

        // GET: DonatingForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonatingForm/Edit/5
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

        // GET: DonatingForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonatingForm/Delete/5
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
