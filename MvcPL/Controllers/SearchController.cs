using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class SearchController:Controller
    {

        private readonly IProfileService profiles;
        private readonly IPhotoService photos;

        public SearchController(IProfileService ps, IPhotoService phs)
        {
            profiles = ps;
            photos = phs;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Consists logic for user searsh
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(SearchModel model, int page = 1)
        {
            var bllProfiles = profiles.Find(model.StringKey, model.City);
            var result = ProfileMapper.Map(bllProfiles);
            model.Profiles = new GenericPaginationModel<ProfileModel>(page,5, result.ToList());
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Search", model);
            }
            else
            {
                return View(model);
            }
        }

        /// <summary>
        /// Returns json autocomplete help
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult FindProfiles(string term)
        {
            var mvcProfiles = profiles.Find(term).Select(p => p.FirstName + " " + p.LastName);
            return Json(mvcProfiles.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}