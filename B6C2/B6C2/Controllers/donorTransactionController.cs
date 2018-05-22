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
                if (transaction.status == "Acceptat")
                    transaction.analysisStatus = "Pozitive";
                else
                {
                    if (transaction.status == "Rebutat")
                        transaction.analysisStatus = "Negative";
                }

                if (transaction.status == "Acceptat")
                {
                    Donor d = db.Donors.Find(transaction.cnpDonor);
                    if (d.idBlood != null)
                    {
                        int idBlood = (int)d.idBlood;
                        int idCenter = (int)transaction.idCenter;
                        bloodResource tt = new bloodResource();
                        foreach (bloodResource t in db.bloodResources.ToList())
                            if (t.idBlood == idBlood && t.idCenter == idCenter)
                                tt = t;

                        tt.quantity = tt.quantity + 500;
                        db.Entry(tt).State = System.Data.Entity.EntityState.Modified;

                        List<Transaction> transactionsListHigh = new List<Transaction>();
                        List<Transaction> transactionsListMedium = new List<Transaction>();
                        List<Transaction> transactionsListLow = new List<Transaction>();
                        foreach (Transaction t in db.Transactions.ToList())
                            if (t.idBlood == idBlood && t.idCenter == idCenter)
                            {
                                if (t.severity == "High")
                                    transactionsListHigh.Add(t);
                                if (t.severity == "Medium")
                                    transactionsListMedium.Add(t);
                                if (t.severity == "Low")
                                    transactionsListLow.Add(t);
                            }

                        foreach (Transaction t in transactionsListHigh)
                            if (t.status == "Prelevare")
                                if (t.quantity <= tt.quantity)
                                {
                                    t.status = "Pregatire";
                                    db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                                    tt.quantity = tt.quantity - t.quantity;
                                    db.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                                }

                        foreach (Transaction t in transactionsListMedium)
                            if (t.status == "Prelevare")
                                if (t.quantity <= tt.quantity)
                                {
                                    t.status = "Pregatire";
                                    db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                                    tt.quantity = tt.quantity - t.quantity;
                                    db.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                                }

                        foreach (Transaction t in transactionsListLow)
                            if (t.status == "Prelevare")
                                if (t.quantity <= tt.quantity)
                                {
                                    t.status = "Pregatire";
                                    db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                                    tt.quantity = tt.quantity - t.quantity;
                                    db.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                                }
                    }
                }
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
