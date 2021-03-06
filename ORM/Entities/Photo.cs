﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Photo
    {
        public Photo()
        {
            Date = DateTime.Now;
            Profile = new HashSet<Profile>();
        }
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public DateTime Date { get; set; }
        public bool IsAvatar { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
