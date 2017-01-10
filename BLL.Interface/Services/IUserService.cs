using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
       public interface IUserService
    {
        void AddUser(BllUser user);
        void DeleteUser(BllUser user);
        void UpdateUser(BllUser user);
        List<BllUser> GetUsers();
        BllUser GetUser(int key);
        IEnumerable<BllUser> Search(string search);
        BllUser GetUserByEmail(string email);
        void MailConfirm (string email);
    }
}
