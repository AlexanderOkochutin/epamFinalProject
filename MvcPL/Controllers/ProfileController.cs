using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;


namespace MvcPL.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService ps)
        {
            profileService = ps;
        }

        [Authorize]
        public ActionResult Home()
        {
            var profile = profileService.Get(1);
            return View(profile.ToViewProfileModel());
        }

        [Authorize]
        public ActionResult ComingSoon()
        {
            return View();
        }

        [Authorize]
        public ActionResult Message()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult Friends()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult Photo()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public ActionResult ChangeAvatar()
        {
            throw new NotImplementedException();
        }

        private void SetProfileImage(PhotoModel photo, HttpPostedFileBase fileUpload)
        {
            if (!ReferenceEquals(fileUpload, null))
            {
                photo.Data = new byte[fileUpload.ContentLength];
                fileUpload.InputStream.Read(photo.Data, 0, fileUpload.ContentLength);
                photo.MimeType = fileUpload.ContentType;
            }

        }
    }
}