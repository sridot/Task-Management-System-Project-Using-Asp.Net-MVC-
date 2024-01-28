using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.ViewModel;
using TaskManagementSystem.BLL;
using System.Web.Security;
using Microsoft.SqlServer.Server;

namespace TaskManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private AccountServices accountServices;
        public AccountController()
        {
            accountServices = new AccountServices();
        }

        // GET: Create New Account
        public ActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("TaskList", "Task");
            }
        }

        // POST: Create New Account
        [HttpPost]
        public ActionResult Register(RegisterViewModel _register)
        {
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                _register.RoleId = 1;
                // if account created sucessfully, then it will return True or else False
                bool isAccountCreated = accountServices.Register(_register);
                if (isAccountCreated)
                    return RedirectToAction("Login", "Account");
            }

            return View(_register);
        }

        // Login
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("TaskList", "Task");
            }
        }

        // Login
        [HttpPost]
        public ActionResult Login(LoginViewModel _login)
        {
            if (ModelState.IsValid)
            {
                

                bool isVerify = accountServices.Login(_login);
                if (isVerify)
                {
                    FormsAuthentication.SetAuthCookie(_login.Username, false);
                    if (_login.Username != "admin" && _login.Username != "Admin")
                    {
                        return RedirectToAction("TaskList", "Task");
                    }
                    else
                    {
                        return RedirectToAction("TaskList", "Admin");
                    }
                }

            }

            return View();
        }

        // Sign Out
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }







    }
}