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
            ViewBag.DonationCenters = new SelectList(GetDonationCentersList(), "Value", "Text");
            return View();
        }

        // POST: DonatingForm/Create
        [HttpPost]
        public ActionResult CreateDonatingForm(DonatingForm donatingForm)
        {
            ViewBag.DonationCenters = new SelectList(GetDonationCentersList(), "Value", "Text");
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
                d.idCenter = donatingForm.idCenter;
                d.status = "Prelevare";
                db.donorTransactions.Add(d);
                db.SaveChanges();
                int idTransaction = db.donorTransactions.Find(d.cnpDonor).id;
                TempData["Success"] = "Your request for donating blood has been submitted! The id of your transaction is " + idTransaction;
                return RedirectToAction("DonationCenterIndex", "DonationCenter");
            }
            TempData["ConditionsNotMet"] = "Sorry, the conditions to donate cannot be applied in your case!";
            return RedirectToAction("DonationCenterIndex", "DonationCenter");
        }
    }
}
