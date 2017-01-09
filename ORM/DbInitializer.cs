using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoService.Interface;


namespace ORM
{
    public class DbInitializer:DropCreateDatabaseIfModelChanges<SocialNetworkContext>
    {

        private readonly IPasswordService passService;

        public DbInitializer(IPasswordService passwordService)
        {
            passService = passwordService;
        }

        protected override void Seed(SocialNetworkContext context)
        {
            context.Roles.AddRange(new DalRole[]
            {
                new DalRole() {Id = 1, Name = "Administrator"},
                new DalRole() {Id = 2, Name = "User"}
            });
            DalUser admin = new DalUser()
            {
                Id = 1,
                Email = "okochutinwork@gmail.com",
                Login = "admin",
                PasswordSalt = passService.GetSalt()
            };
            admin.Password = passService.GetHash("123456", admin.PasswordSalt);
            var adminRoles = context.Set<DalRole>().Select(r => r);
            foreach (var role in adminRoles)
            {
                admin.Roles.Add(role);
            }
            context.Set<DalUser>().Add(admin);
            context.SaveChanges();
        }


    }
}
