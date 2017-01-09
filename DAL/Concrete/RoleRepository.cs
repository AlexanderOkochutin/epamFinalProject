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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalRole role)
        {
            context.Set<DalRole>().Add(role);
        }

        public void Delete(DalRole role)
        {
            context.Set<DalRole>().Remove(role);
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<DalRole>().Select(r => r);
        }

        public DalRole GetById(int key)
        {
            return context.Set<DalRole>().FirstOrDefault(r => r.Id == key);
        }

        public IEnumerable<DalRole> GetByPredicate(Expression<Func<DalRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole role)
        {
            throw new NotImplementedException();
        }
    }
}
