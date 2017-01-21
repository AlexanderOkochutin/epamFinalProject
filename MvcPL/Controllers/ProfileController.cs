using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;
using Ninject.Infrastructure.Language;


namespace MvcPL.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IPhotoService photoService;
        private readonly IUserService userService;

        public ProfileController(IProfileService ps, IPhotoService phs, IUserService us)
        {
            profileService = ps;
            photoService = phs;
            userService = us;
        }

        [Authorize]
        public ActionResult Home()
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            if (user == null) return RedirectToAction("Login", "Account");
            var profile = profileService.Get(user.Id);
            return View(profile.ToViewProfileModel());
        }


        [Authorize]
        [Route("User", Name = "User")]
        public ActionResult UserProfile(int id)
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            var profile = profileService.Get(id);
            if (user.Id == id)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return View(profile.ToViewProfileModel());
            }
        }
        [Authorize]
        public ActionResult ComingSoon()
        {
            return View();
        }

        [Authorize]
        public ActionResult Message()
        {
            profileService.AddFriend(1,2);
            return RedirectToAction("Home", "Profile");
        }

        [Authorize]
        public ActionResult Friends()
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            var requests = profileService.GetAllRequests(user.Id);
            return View(ProfileMapper.Map(requests));
        }

        [Authorize]
        [Route("AcceptFriend", Name = "AcceptFriend")]
        public ActionResult AcceptFriend(int id)
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            profileService.AddFriend(user.Id,id);
            if (Request.IsAjaxRequest())
            {
                return PartialView("__AcceptFriend");
            }
            else
            {
                return RedirectToAction("Home");
            }
        }

        [Authorize]
        [Route("RefuseFriend", Name = "RefuseFriend")]
        public ActionResult RefuseFriend()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            var profile = profileService.Get(user.Id);
            return View(profile.ToViewProfileModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(ProfileModel model,HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                SetProfileImage(model,fileUpload);
                profileService.Update(model.ToBllProfile());
            }
            return RedirectToAction("Home");
        }

        [Authorize]
        [Route("Request",Name = "Request")]
        public ActionResult SendFriendRequest(int id)
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            profileService.SendRequest(user.Id,id);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_RequestSend");
            }
            return RedirectToAction("Home");
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

        private void SetProfileImage( ProfileModel model,HttpPostedFileBase fileUpload)
        {
            var photo = new PhotoModel();

            if (!ReferenceEquals(fileUpload, null))
            {
                var previousAvatar = photoService.GetAllPhotos(model.Id).FirstOrDefault(p => p.IsAvatar);
                if (previousAvatar != null)
                {
                    previousAvatar.IsAvatar = false;
                    photoService.UpdatePhoto(previousAvatar);
                }
                photo.Data = new byte[fileUpload.ContentLength];
                fileUpload.InputStream.Read(photo.Data, 0, fileUpload.ContentLength);
                photo.MimeType = fileUpload.ContentType;
                photo.IsAvatar = true;
                photo.ProfileId.Add(model.Id);
                photoService.AddPhoto(photo.ToBllPhoto());
                var avatar = photoService.GetAllPhotos(model.Id).FirstOrDefault(p => p.IsAvatar == true);
                model.AvatarId = avatar.Id;
            }
            else
            {
                model.AvatarId = 0;
            }
        }

        [AllowAnonymous]
        public FileContentResult GetImage(int id)
        {
            var profile = profileService.Get(id);
            if (profile != null)
            {
                var avatarId = profile.AvatarId;
                
                if (avatarId != 0)
                {
                    var photo = photoService.GetPhoto(avatarId);
                    return File(photo.Data,photo.MimeType);
                }
                else
                {
                    return StandartImage();
                }
            }
            return null;
        }

        private FileContentResult StandartImage()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Content/default-avatar.jpg");
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "image/jpg");
        }

    }
}