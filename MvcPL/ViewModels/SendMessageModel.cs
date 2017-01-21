using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using BLL.Interface.Entities;

namespace MvcPL.ViewModels
{
    public class SendMessageModel
    {
        public ProfileModel I { get; set; }
        public ProfileModel Companion { get; set; }
        public IEnumerable<BllMessage> Messages { get; set; }
    }
}