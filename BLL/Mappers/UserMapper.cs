using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using ORM;

namespace BLL.Mappers
{
    static class UserMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static BllUser ToBllUser(this DalUser user)
        {
            if (ReferenceEquals(user, null)) return null;
            BllUser result = new BllUser
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                PasswordSalt = user.PasswordSalt,
                Roles = user.Roles,
                IsEmailConfirmed = user.IsEmailConfirmed
            };

            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static DalUser ToDalUser(this BllUser user)
        {
            if (ReferenceEquals(user, null)) return null;
            DalUser result = new DalUser
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                PasswordSalt = user.PasswordSalt,
                Roles = user.Roles,
                IsEmailConfirmed = user.IsEmailConfirmed
            };

            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<BllUser> Map(IEnumerable<DalUser> users)
        {
            var bllUsers = new List<BllUser>();
            foreach (var item in users)
            {
                bllUsers.Add(item.ToBllUser());
            }
            return bllUsers;
        }

    }
}
