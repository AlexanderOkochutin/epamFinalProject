using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class SocialNetworkContext:DbContext
    {
        public SocialNetworkContext() : base("SocialNetworkContext") { }
        public DbSet<DalUser> Users;
        public DbSet<DalRole> Roles;
    }
}
