using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL Layout User class
    /// </summary>
    public class DalUser:IEntity
    {
        /// <summary>
        /// CreatesDalUser entity
        /// </summary>
        public DalUser()
        {
            Roles = new List<string>();
        }

        /// <summary>
        /// DAL User identify number 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DAL User Login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// DAL User Email
        /// </summary>
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// DAL User hashed password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// DAL User password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// DAL User roles
        /// </summary>
        public ICollection<string> Roles { get; set; }
    }
}
