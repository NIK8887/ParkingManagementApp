using ParkingManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ParkingManagementApp.Controllers
{
    public class AccountController : Controller
    {
        BusinessLayer.AccountService _accountservice = new BusinessLayer.AccountService();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                DataSet loginds = new DataSet();
                loginds = _accountservice.AuthenticateUser(loginModel.Username,loginModel.Password);

                if (loginds.Tables[0].Rows[0]["Status"].ToString()=="Valid")
                {
                    FormsAuthentication.SetAuthCookie("Nikhil Yewale", false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Invalid username and password");
                    return View("Index");
                }
            }
            else
            {
                ModelState.AddModelError("Error","Invalid request");
                return View("Index");
            }
            
        }
        public ActionResult Logout()
        {
            
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }


}