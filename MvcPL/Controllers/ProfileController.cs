using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class ProfileController:Controller
    {

        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        [Authorize]
        public ActionResult ComingSoon()
        {
            return View();
        }
    }
}