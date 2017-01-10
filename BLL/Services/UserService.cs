using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public void AddUser(BllUser user)
        {
            uow.Users.Create(user.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(BllUser user)
        {
            uow.Users.Delete(user.Id);
            uow.Commit();
        }

        public BllUser GetUser(int key)
        {
            return uow.Users.Get(key).ToBllUser();
        }

        public BllUser GetUserByEmail(string email)
        {
            return uow.Users.GetByEmail(email).ToBllUser();
        }

        public List<BllUser> GetUsers()
        {
            return uow.Users.GetAll().Select(user=>user.ToBllUser()).ToList();
        }

        public IEnumerable<BllUser> Search(string search)
        {
           throw new NotImplementedException();
        }

        public void UpdateUser(BllUser user)
        {
            uow.Users.Update(user.ToDalUser());
            uow.Commit();
        }
    }
}
