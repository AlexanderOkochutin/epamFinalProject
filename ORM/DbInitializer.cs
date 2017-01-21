using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoService.Interface;
using ORM.Entities;


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
            Profile adminProfile = new Profile()
            {
                Id = admin.Id,
                FirstName = "Alexander",
                LastName = "Okochutin",
                Gender = "Male",
                BirthDay = new DateTime(1994,6,25),
                RelationStatus = "Free"
            };
            context.Set<Profile>().Add(adminProfile);
            User user1 = new User()
            {
                Id = 2,
                Email = "user1@gmail.com",
                IsEmailConfirmed = true,
                Login = "user1",
                PasswordSalt = passService.GetSalt()
            };
            user1.Password = passService.GetHash("123456", user1.PasswordSalt);
            var user1Roles = context.Set<Role>().FirstOrDefault(r=>r.Name=="User");
            user1.Roles.Add(user1Roles);
            context.Set<User>().Add(user1);
            Profile user1Profile = new Profile()
            {
                Id = user1.Id,               
            };
            context.Set<Profile>().Add(user1Profile);
            context.SaveChanges();

            User user2 = new User()
            {
                Id = 3,
                Email = "user2@gmail.com",
                IsEmailConfirmed = true,
                Login = "user2",
                PasswordSalt = passService.GetSalt()
            };
            user2.Password = passService.GetHash("123456", user2.PasswordSalt);
            var user2Roles = context.Set<Role>().FirstOrDefault(r => r.Name == "User");
            user2.Roles.Add(user2Roles);
            context.Set<User>().Add(user2);
            Profile user2Profile = new Profile()
            {
                Id = user2.Id,
            };
            context.Set<Profile>().Add(user2Profile);
            context.SaveChanges();

            User user3 = new User()
            {
                Id = 4,
                Email = "user3@gmail.com",
                IsEmailConfirmed = true,
                Login = "user3",
                PasswordSalt = passService.GetSalt()
            };
            user3.Password = passService.GetHash("123456", user3.PasswordSalt);
            var user3Roles = context.Set<Role>().FirstOrDefault(r => r.Name == "User");
            user3.Roles.Add(user3Roles);
            context.Set<User>().Add(user3);
            Profile user3Profile = new Profile()
            {
                Id = user3.Id,
            };
            context.Set<Profile>().Add(user3Profile);
            context.SaveChanges();
        }


    }
}
