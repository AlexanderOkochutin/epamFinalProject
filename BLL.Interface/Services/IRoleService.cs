using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        void AddRole(BllRole role);
        void DeleteRole(BllRole role);
        void UpdateRole(BllRole role);
        List<BllRole> GetAllRoles();
        BllRole GetRoleById(int key);
    }
}
