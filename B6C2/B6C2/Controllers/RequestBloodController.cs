﻿using B6C2.Models;
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
        // GET: ReguestBlood/Create
        public ActionResult RequestBloodCreate()
        {
            return View();
        }

        // POST: RequestBlood/Create
        [HttpPost]
        public ActionResult RequestBloodCreate(RequestBlood req)
        {

            if (ModelState.IsValid)
            {

                Transaction t = new Transaction();
                t.idBlood = req.idBlood;
                t.status = "In curs de aprobare";
                t.idCenter = 1;
                t.idHospital = 3;
                t.quantity = req.quantity;
                
                db.Transactions.Add(t);
                db.SaveChanges();
                TempData["Success"] = "Request blood submitted!";
                return RedirectToAction("MedicIndex", "Medic");
            }
            return View();
        }


    }
}
