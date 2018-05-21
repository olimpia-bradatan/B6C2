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

        private List<SelectListItem> GetDonationCentersList() => db.donationCenters
              .Select(e => new SelectListItem
              {
                  Value = e.idCenter.ToString(),
                  Text = e.name
              })
             .ToList();

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
        [Authorize(Roles = "Donor")]
        public ActionResult CreateDonatingForm()
        {
            ViewBag.DonationCenters = new SelectList(GetDonationCentersList(), "Value", "Text");
            return View();
        }

        // POST: DonatingForm/Create
        [HttpPost]
        [Authorize(Roles = "Donor")]
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

            var donorTransactions = from row in db.donorTransactions.ToArray()
                                    where row.cnpDonor == donatingForm.cnp
                                    select row.donationDate;

            if (donorTransactions.ToList().Count > 0)
            { 

                if (donorTransactions.Last().HasValue)
                {

                    var lastTransaction = donorTransactions.Last() ?? DateTime.Now.Date;

                    var today = DateTime.Now.Date;
                    TimeSpan daysBetweenDonations = today.Subtract(value: lastTransaction.Date);

                    if (daysBetweenDonations.Days <= 90)
                    {
                        var nextPossibleDate = lastTransaction.AddDays(90);
                        TempData["ConditionsNotMet"] = "Sorry, the minimum period of time between two donations is 90 days! The next date you can donate is: " + nextPossibleDate.Date + ".";
                        return RedirectToAction("CreateDonatingForm", "DonatingForm");
                    }

                }
            }

            if (age >= 18 && age <= 60 && weight >= 50 && pulse >= 60 && pulse <= 100 && !pregnancy && !drinking && !intervention && !affections)
            {
                donorTransaction d = new donorTransaction();
                d.cnpDonor = donatingForm.cnp;
                d.idCenter = donatingForm.idCenter;
                d.status = "Prelevare";
                Donor donor = db.Donors.Find(donatingForm.cnp);
                donor.idCenter = donatingForm.idCenter;
                d.donationDate = DateTime.Now.Date;
                db.donorTransactions.Add(d);
                db.SaveChanges();
                int idTransaction = db.donorTransactions.Where(a => a.cnpDonor == donatingForm.cnp).FirstOrDefault().id;
                TempData["Success"] = "Your request for donating blood has been submitted! The id of your transaction is " + idTransaction;
                return RedirectToAction("CreateDonatingForm", "DonatingForm");
            }
            TempData["ConditionsNotMet"] = "Sorry, the conditions to donate cannot be applied in your case!";
            return RedirectToAction("CreateDonatingForm", "DonatingForm");
        }
    }
}
