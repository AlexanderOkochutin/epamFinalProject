using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using MvcPL.Providers;
using MvcPL.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MvcPL.Providers;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService us)
        {
            userService = us;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    //Управляет службами проверки подлинности с помощью форм для веб-приложений
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Home", "Profile");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }




        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {

            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdeCREUAAAAAOLw6oV8FAwizRxR7ZNTBH0iSdxV";
            var client = new WebClient();
            var result =
                client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");
            var obj = JObject.Parse(result);
            var status = (bool) obj.SelectToken("success");
            /*if (!status)
            {
                ModelState.AddModelError("", "captcha failed");
                return View(model);
            }*/
            var anyUser = userService.GetUsers().Any(u => u.Email == model.Email);
            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var membershipUser = ((SocialNetworkMembershipProvider)Membership.Provider)
                    .CreateUser(model);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(model);
        }
    }
}