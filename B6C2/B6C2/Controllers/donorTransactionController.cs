using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class donorTransactionController : Controller
    {
        ISSContext db = new ISSContext();
        // GET: donorTransaction
        public ActionResult DonorTransactionIndex()
        {   
            return View(db.donorTransactions.ToList());
        }

        // GET: DonationCenter/Edit/5
        [Authorize(Roles = "CentreEmployee")]

        public ActionResult DonorTransactionEdit(int id)
        {
            return View(db.donorTransactions.Find(id));
        }

        // POST: DonationCenter/Edit/5
        [Authorize(Roles = "CentreEmployee")]
        [HttpPost]
        public ActionResult DonorTransactionEdit(int id, donorTransaction transaction)
        {
            try
            {
                db.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Donor transaction successfully updated!";
                return RedirectToAction("DonorTransactionIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
