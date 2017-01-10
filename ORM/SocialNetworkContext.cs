using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoService.Interface;

namespace ORM
{
    public class SocialNetworkContext:DbContext
    {
        public SocialNetworkContext(IPasswordService passwordService) : base("SocialNetworkContext")
        {
            Database.SetInitializer(new DbInitializer(passwordService));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
