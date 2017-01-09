using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalUser dalUser)
        {
            context.Set<DalUser>().Add(dalUser);
        }

        public void Delete(DalUser dalUser)
        {
            context.Set<DalUser>().Remove(dalUser);
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<DalUser>().ToList();
        }

        public DalUser GetByEmail(string email)
        {
            return context.Set<DalUser>().FirstOrDefault(u => u.Email==email);
        }

        public DalUser GetById(int key)
        {
            return context.Set<DalUser>().Find(key);
        }

        public IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> predicate)
        {
            return context.Set<DalUser>().Where(predicate);
        }

        public void Update(DalUser dalUser)
        {
            var oldUser = GetById(dalUser.Id);
            context.Entry(oldUser).CurrentValues.SetValues(dalUser);
        }
    }
}
