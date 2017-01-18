using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ORM.Entities
{
    public class Profile
    {
        public Profile()
        {
            Photos = new HashSet<Photo>();
            Messages = new HashSet<Message>();
            Friends = new HashSet<Profile>();
            InFriends = new HashSet<Profile>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string RelationStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Profile> Friends { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Profile> InFriends { get; set; }
     }
}
