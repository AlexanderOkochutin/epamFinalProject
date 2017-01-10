using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{

    /// <summary>
    /// ORM Layout User class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Create ORM User ENtity
        /// </summary>
        public User()
        {
            Roles = new List<Role>();
        }

        /// <summary>
        /// User identify number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// User hashed password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// User Roles. It need for DataBase creating
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
    }
}
