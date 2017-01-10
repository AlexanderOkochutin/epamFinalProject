using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoService.Interface;


namespace ORM
{
    public class DbInitializer:CreateDatabaseIfNotExists<SocialNetworkContext>
    {

        private readonly IPasswordService passService;

        public DbInitializer(IPasswordService passwordService)
        {
            passService = passwordService;      
             
        }

        protected override void Seed(SocialNetworkContext context)
        {
            context.Roles.AddRange(new Role[]
            {
                new Role() {Id = 1, Name = "Administrator"},
                new Role() {Id = 2, Name = "User"}
            });
            context.SaveChanges();
            User admin = new User()
            {
                Id = 1,
                Email = "okochutinwork@gmail.com",
                IsEmailConfirmed = true,
                Login = "admin",
                PasswordSalt = passService.GetSalt()
            };
            admin.Password = passService.GetHash("123456", admin.PasswordSalt);
            var adminRoles = context.Set<Role>().Select(r => r);
            foreach (var role in adminRoles)
            {
                admin.Roles.Add(role);
            }
            context.Set<User>().Add(admin);
            context.SaveChanges();
        }


    }
}
