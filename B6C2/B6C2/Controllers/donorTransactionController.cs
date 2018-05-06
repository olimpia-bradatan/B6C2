using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class donorTransactionController : Controller
    {
        ISSContext DB = new ISSContext();
        // GET: donorTransaction
        public ActionResult DonorTransactionIndex()
        {   
            return View(DB.donorTransactions.ToList());
        }
    }
}
