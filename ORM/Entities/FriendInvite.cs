using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class FriendInvite
    {
        public int Id { get; set; }
        public virtual Profile FromProfile { get; set; }
        public virtual Profile ToProfile { get; set; }
        public bool? Response { get; set; }
    }
}
