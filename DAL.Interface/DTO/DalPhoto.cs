﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalPhoto:IEntity
    {
        public DalPhoto()
        {
            Date = DateTime.Now;
            ProfileId = new HashSet<int>();
        }
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public DateTime Date { get; set; }
        public ICollection<int> ProfileId { get; set; }

    }
}
