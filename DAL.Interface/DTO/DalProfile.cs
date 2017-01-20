using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.DTO
{

    public class DalProfile : IEntity
    {
        public DalProfile()
        {
            Friends = new HashSet<int>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string RelationStatus { get; set; }
        public int AvatarId { get; set; }
        public bool IsNewInvites { get; set; }
        public ICollection<int> Friends { get; set; }
    }
}
