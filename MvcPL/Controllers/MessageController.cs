using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class MessageController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IUserService userService;
        private readonly IMessageService messageService;

        public MessageController(IProfileService ps, IMessageService ms,IUserService us)
        {
            profileService = ps;
            messageService = ms;
            userService = us;
        }

        [HttpGet]
        [Authorize]
        public ActionResult SendMessage(int id, string chatMessage = null)
        {
            
            var myUser = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            if (chatMessage != null)
            {
                messageService.AddMessage(new BllMessage()
                {
                    Date = DateTime.Now,
                    ProfileIdFrom = myUser.Id,
                    ProfileIdTo = id,
                    Text = chatMessage
                });
            }
            var messages = messageService.GetMessages(myUser.Id, id);         
            var viewModel = new SendMessageModel()
            {
                Messages = messages,
                I = profileService.Get(myUser.Id).ToViewProfileModel(),
                Companion = profileService.Get(id).ToViewProfileModel()
            };
            if (!Request.IsAjaxRequest())
            {
                return View(viewModel);
            }
            return PartialView("_History",viewModel);
        }
    }
}