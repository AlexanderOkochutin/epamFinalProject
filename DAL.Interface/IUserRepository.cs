using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Interface
{
    /// <summary>
    /// Interface for IRepository addons for User collection
    /// </summary>
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByEmail(string email);
    }
}
