using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class CenterEmployeesController : Controller
    {
        ISSContext db = new ISSContext();


        // GET: DonationCenterEmployees
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesIndex()
        {
            return View(db.centerEmployees.ToList());
        }

        // GET: DonationCenterEmployees/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesDetails(int id)
        {
            return View(db.centerEmployees.Find(id));
        }

        // GET: DonationCenterEmployees/Create
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesCreate()
        {
            return View();
        }

        // POST: DonationCenterEmployees/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesCreate(centerEmployee centerEmployee)
        {
            if (ModelState.IsValid)
            {
                CenterEmployeeComparer cmp = new CenterEmployeeComparer();
                int ok = 1;
                if (db.centerEmployees.Count() > 0)
                {
                    foreach (var d in db.centerEmployees)
                        if (cmp.Equals(d, centerEmployee))
                            ok = 0;
                }
                if (ok == 1)
                {
                    TempData["Success"] = "Center Employee successfully added!";
                    db.centerEmployees.Add(centerEmployee);
                    db.SaveChanges();
                    return RedirectToAction("CenterEmployeesIndex");
                }
                else
                {
                    TempData["Warning"] = "Center Emplyee already exists! Try add another one!";
                    return RedirectToAction("CenterEmployeesCreate");
                }
            }
            return View();
        }

        // GET: DonationCenterEmployees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesEdit(int id)
        {
            return View(db.centerEmployees.Find(id));
        }

        // POST: DonationCenterEmployees/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesEdit(int id, centerEmployee centerEmployee)
        {
            try
            {
                db.Entry(centerEmployee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Center Empolyee successfully updated!";
                return RedirectToAction("CenterEmployeesIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: DonationCenterEmployees/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesDelete(int id)
        {
            return View(db.centerEmployees.Find(id));
        }

        // POST: DonationCenterEmployees/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CenterEmployeesDelete(int id, centerEmployee centerEmployee)
        {
            try
            {
                db.centerEmployees.Remove(db.centerEmployees.Find(id));
                db.SaveChanges();
                TempData["Success"] = "Center Employee successfully deleted!";
                return RedirectToAction("CenterEmployeesIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult SendEmail(Donor donor)
        {
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "test57681";
                WebMail.Password = "test57681test57681";


                //Sender email address.  
                WebMail.From = "test57681@gmail.com";
                string text = "Dear " + donor.firstName +" "+donor.lastName+"," + "<br/> " + "Because of the high number of patients, we need a big quantity of blood at the center "+db.donationCenters.Find(donor.idCenter).name+" with the adress "+ db.donationCenters.Find(donor.idCenter).address +". If you are close to the center, please do not hesitate to pay us a visit in order to make a blood donation.<br/>" + "We are looking forward to you helping us as soon as possible.";

                //Send email  
                WebMail.Send(to: donor.email, subject: "Blood needed", body: text, isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }
            return View();
        }
    }
}
