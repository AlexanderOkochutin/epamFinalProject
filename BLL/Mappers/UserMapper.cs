using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using ORM;

namespace BLL.Mappers
{
    static class UserMapper
    {
        public static DalUser ToDalUser(this BllUser user)
        {
            if (ReferenceEquals(user, null)) return null;
            DalUser result = new DalUser
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                PasswordSalt = user.PasswordSalt
            };

            return result;
        }

        public static BllUser ToBllUser(this DalUser user)
        {
            if (ReferenceEquals(user, null)) return null;
            BllUser result = new BllUser
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                PasswordSalt = user.PasswordSalt
            };

            foreach (var role in user.Roles)
            {
                result.Roles.Add(role.Name);
            }

            return result;
        }
    }
}
