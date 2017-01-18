using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalMessage:IEntity
    {
        public int Id { get; set; }
        public int ProfileIdFrom { get; set; }
        public int ProfileIdTo { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
