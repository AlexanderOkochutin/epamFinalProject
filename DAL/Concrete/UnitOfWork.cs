using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using ORM;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {

        public DbContext Context { get; private set; }

        public IUserRepository Users { get; set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
            Users = new UserRepository((SocialNetworkContext)context);
        }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
