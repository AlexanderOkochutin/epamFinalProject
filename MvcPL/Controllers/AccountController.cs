﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using MvcPL.Providers;
using MvcPL.ViewModels;
using Newtonsoft.Json.Linq;


namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public AccountController(IUserService us, IProfileService ps)
        {
            userService = us;
            profileService = ps;
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
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    //Управляет службами проверки подлинности с помощью форм для веб-приложений
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        var user = userService.GetUserByEmail(viewModel.Email);
                        if (user.IsEmailConfirmed)
                        {
                            return RedirectToAction("Home", "Profile");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email is not confurmed");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
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
                
                var membershipUser = ((SocialNetworkMembershipProvider)Membership.Provider)
                    .CreateUser(model);

                MailConfirmation(model.Email);

                if (membershipUser != null)
                {
                    return RedirectToAction("Confirm", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult Confirm()
        {
            ViewBag.Message = "check your email to complete your registration";
            return View();
        }


        //ПРОДУМАТЬ ЗАЩИТУ ОТ ПЕРЕХОДА НА ЭТУ ССЫЛКУ
        [AllowAnonymous]
        public ActionResult ConfirmEmail(string Email)
        {
            if (!userService.GetUserByEmail(Email).IsEmailConfirmed)
            {
                userService.MailConfirm(Email);
            }
            return RedirectToAction("Login", "Account");
        }


        private void MailConfirmation(string email)
        {
            // наш email с заголовком письма
            MailAddress from = new MailAddress("f-society@mail.com", "Web Registration");
            // кому отправляем
            MailAddress to = new MailAddress(email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Email confirmation";
            // текст письма - включаем в него ссылку
            m.Body = string.Format("To complete registration go to this link:" +
                            "<a href=\"{0}\" title=\"Confirm registration\">{0}</a>",
                Url.Action("ConfirmEmail", "Account", new {Email = email }, Request.Url.Scheme));
            m.IsBodyHtml = true;
            // адрес smtp-сервера, с которого мы и будем отправлять письмо
            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("okochutinwork@gmail.com", "GooOko331650");
            smtp.Send(m);
        }

    }
}