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
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository)
        {
            uow = unitOfWork;
            userRepository = repository;
        }

        public void AddUser(BllUser user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(BllUser user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }

        public BllUser GetUser(int key)
        {
            return userRepository.GetById(key).ToBllUser();
        }

        public BllUser GetUserByEmail(string email)
        {
            return userRepository.GetByEmail(email).ToBllUser();
        }

        public List<BllUser> GetUsers()
        {
            return userRepository.GetAll().Select(user=>user.ToBllUser()).ToList();
        }

        public IEnumerable<BllUser> Search(string search)
        {
            var s = search ?? "";
            s = s.ToLower();
            return userRepository.GetByPredicate(u => (u.Email.ToLower() + " " + u.Login.ToLower()).Contains(s)).Select(u=>u.ToBllUser());
        }

        public void UpdateUser(BllUser user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }
    }
}
