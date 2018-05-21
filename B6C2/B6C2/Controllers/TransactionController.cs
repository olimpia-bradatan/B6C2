using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class TransactionController : Controller
    {
        ISSContext db = new ISSContext();
        // GET: Transaction
        [Authorize(Roles = "CentreEmployee, Medic")]
        public ActionResult TransactionIndex()
        {
            return View(db.Transactions.ToList());
        }

        // GET: Transaction/Details/5
        [Authorize(Roles = "CentreEmployee, Medic")]
        public ActionResult TransactionDetails(int id)
        {
            return View(db.Transactions.Find(id));
        }

        // GET: Donor/Edit/5
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult TransactionEdit(int id)
        {
            return View(db.Transactions.Find(id));
        }

        // POST: Donor/Edit/5
        [HttpPost]
        [Authorize(Roles = "CentreEmployee")]
        public ActionResult TransactionEdit(int id, Transaction transaction)
        {
            try
            {
                db.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Tranzaction with id" + id + " was successfully updated!";
                return RedirectToAction("TransactionIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
