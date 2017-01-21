﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class SearchModel
    {
        /// <summary>
        /// Part of user name
        /// </summary>
        public string StringKey { get; set; }

        /// <summary>
        /// User city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Finded users
        /// </summary>
        public GenericPaginationModel<ProfileModel> Profiles { get; set; }

    }
}