using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllMessage
    {
        public int Id { get; set; }
        public int ProfileIdFrom { get; set; }
        public int ProfileIdTo { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
