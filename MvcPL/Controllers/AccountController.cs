using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using SocialNetwork.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService us)
        {
            userService = us;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        
        
        [AllowAnonymous]
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
            if (!status)
            {
                ModelState.AddModelError("", "captcha failed");
                return View(model);
            }
            var anyUser = userService.GetUsers().Any(u => u.Email == model.Email);
            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var membershipUser = ((SocailNetworkMembershipProvider)Membership.Provider)
                    .CreateUser(model);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Home", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
        }
    }
}