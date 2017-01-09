using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using ORM;

namespace BLL.Mappers
{
    public static class RoleMapper
    {
        public static DalRole ToDalRole(this BllRole bllRole)
        {
            return new DalRole()
            {
                Id = bllRole.Id,
                Name = bllRole.Name,
                Users = bllRole.Users.Select(u=>u.ToDalUser()).ToList()
            };
        }

        public static BllRole ToBllRole(this DalRole dalRole)
        {
            return new BllRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Users = dalRole.Users.Select(u=>u.ToBllUser()).ToList()
            };
        }
    }
}
