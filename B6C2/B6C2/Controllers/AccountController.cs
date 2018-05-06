using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using B6C2.Models;
using System.Data.Entity.Validation;
using PC.CustomLibraries;

namespace B6C2.Controllers
{
    public class AccountController : Controller
    { 
        ISSContext db = new ISSContext();

        public AccountController()
        {
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var emailCheck = db.AspNetUsers.FirstOrDefault(u => u.Email == user.Email);
            if (emailCheck != null)
            {
                var getPassword = db.AspNetUsers.Where(u => u.Email == user.Email).Select(u => u.Password);
                var materializePassword = getPassword.ToList();
                var password = materializePassword[0];

                var encryptedPass = CustomEncrypt.Encrypt(user.Password);
                if (encryptedPass == password)
                {
                    string name = "";
                    if (db.Donors.Any(d => d.email == user.Email) == true)
                    {
                        var getFirstName = db.Donors.Where(u => u.email == user.Email).Select(u => u.firstName);
                        var materName = getFirstName.ToList();
                        var firstName = materName[0];

                        var getName1 = db.Donors.Where(u => u.email == user.Email).Select(u => u.lastName);
                        var materName1 = getName1.ToList();
                        var lastName = materName1[0];

                        name = firstName + " " + lastName;
                    }
                    else
                    {
                        if (db.Medics.Any(d => d.email == user.Email) == true)
                        {
                            var getFirstName = db.Medics.Where(u => u.email == user.Email).Select(u => u.firstName);
                            var materName = getFirstName.ToList();
                            var firstName = materName[0];

                            var getName1 = db.Medics.Where(u => u.email == user.Email).Select(u => u.lastName);
                            var materName1 = getName1.ToList();
                            var lastName = materName1[0];

                            name = firstName + " " + lastName;
                        }
                        else
                        {
                            if (db.centerEmployees.Any(d => d.email == user.Email) == true)
                            {
                                var getFirstName = db.centerEmployees.Where(u => u.email == user.Email).Select(u => u.firstName);
                                var materName = getFirstName.ToList();
                                var firstName = materName[0];

                                var getName1 = db.centerEmployees.Where(u => u.email == user.Email).Select(u => u.lastName);
                                var materName1 = getName1.ToList();
                                var lastName = materName1[0];

                                name = firstName + " " + lastName;
                            }
                        }
                    }

                    var getEmail = db.AspNetUsers.Where(u => u.Email == user.Email).Select(u => u.Email);
                    var materializeEmail = getEmail.ToList();
                    var email = materializeEmail[0];


                    var idRole = db.AspNetUsers.Where(u => u.Email == user.Email).Select(u => u.idRole);
                    var materializeRole = idRole.ToList();
                    var role = materializeRole[0];

                    var roleName = db.AspNetRoles.Find(role).Name.ToString();

                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, name),
                        new Claim(ClaimTypes.Email, email),
                        new Claim(ClaimTypes.Role, roleName)
                }, "ApplicationCookie");
                    var ctx = Request.GetOwinContext();
                    var accountManager = ctx.Authentication;
                    accountManager.SignIn(identity);
                    TempData["SuccessRegistration"] = "You signed in into your account as ";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The password is incorrect");
                }
            }
            else
            {
                ModelState.AddModelError("", "The email is incorrect");

            }
            return View(user);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterDonor()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegisterDonor(DonorRegisterViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var encryptedPassword = CustomEncrypt.Encrypt(user.Password);
                    if (db.AspNetUsers.FirstOrDefault(o => o.Email == user.Email) != null)
                    {
                        TempData["UserAlreadyExists"] = "This donor already exists";
                        return View(user);
                    }
                    var donor = new Donor();
                    donor.cnp = user.CNP;
                    donor.firstName = user.firstName;
                    donor.lastName = user.lastName;
                    donor.birthDate = user.birthDate;
                    donor.address = user.address;
                    donor.email = user.Email;
                    donor.phoneNumber = user.phoneNumber;
                    db.Donors.Add(donor);

                    var userDb = new AspNetUser();
                    userDb.Email = user.Email;
                    userDb.Password = encryptedPassword;
                    userDb.idRole = 1;
                    db.AspNetUsers.Add(userDb);
                    db.SaveChanges();
                    TempData["SuccessRegistration"] = "You registered successfully";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return View(user);
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }


        [AllowAnonymous]
        public ActionResult RegisterMedic()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegisterMedic(MedicRegisterViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var encryptedPassword = CustomEncrypt.Encrypt(user.Password);

                    if (db.AspNetUsers.Any(o => o.Email == user.Email))
                    {
                        TempData["UserAlreadyExists"] = "This medic already exists";
                        return View(user);
                    }
                    var medic = new Medic();
                    medic.firstName = user.firstName;
                    medic.lastName = user.lastName;
                    medic.email = user.Email;
                    db.Medics.Add(medic);

                    var userDb = new AspNetUser();
                    userDb.Email = user.Email;
                    userDb.Password = encryptedPassword;
                    userDb.idRole = 3;
                    db.AspNetUsers.Add(userDb);
                    db.SaveChanges();
                    TempData["SuccessRegistration"] = "You registered successfully";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return View(user);
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }


        [AllowAnonymous]
        public ActionResult RegisterCentreEmployee()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegisterCentreEmployee(CentreEmployeeRegisterViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var encryptedPassword = CustomEncrypt.Encrypt(user.Password);

                    if (db.AspNetUsers.Any(o => o.Email == user.Email))
                    {
                        TempData["UserAlreadyExists"] = "This employee already exists";
                        return View(user);
                    }
                    var employee = new centerEmployee();
                    employee.firstName = user.firstName;
                    employee.lastName = user.lastName;
                    employee.email = user.Email;
                    db.centerEmployees.Add(employee);

                    var userDb = new AspNetUser();
                    userDb.Email = user.Email;
                    userDb.Password = encryptedPassword;
                    userDb.idRole = 2;
                    db.AspNetUsers.Add(userDb);
                    db.SaveChanges();
                    TempData["SuccessRegistration"] = "You registered successfully";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return View(user);
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}