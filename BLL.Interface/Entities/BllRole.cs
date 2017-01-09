using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllRole
    {
        public BllRole()
        {
            Users = new List<BllUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BllUser> Users { get; set; }

    }
}
