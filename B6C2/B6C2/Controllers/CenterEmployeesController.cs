using B6C2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B6C2.Controllers
{
    public class CenterEmployeesController : Controller
    {
        ISSContext db = new ISSContext();
        // GET: DonationCenterEmployees
        public ActionResult CenterEmployeesIndex()
        {
            return View(db.centerEmployees.ToList());
        }

        // GET: DonationCenterEmployees/Details/5
        public ActionResult CenterEmployeesDetails(int id)
        {
            return View(db.centerEmployees.Find(id));
        }

        // GET: DonationCenterEmployees/Create
        public ActionResult CenterEmployeesCreate()
        {
            return View();
        }

        // POST: DonationCenterEmployees/Create
        [HttpPost]
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
        public ActionResult CenterEmployeesEdit(int id)
        {
            return View(db.centerEmployees.Find(id));
        }

        // POST: DonationCenterEmployees/Edit/5
        [HttpPost]
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
        public ActionResult CenterEmployeesDelete(int id)
        {
            return View(db.centerEmployees.Find(id));
        }

        // POST: DonationCenterEmployees/Delete/5
        [HttpPost]
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
    }
}
