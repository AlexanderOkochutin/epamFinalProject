using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class ProfileModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public string UserEmail { get; set; }
        public int UserPhotoId { get; set; }
        public string DisplayName => UserName + " " + UserSurname;
    }
}