using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Services;
using CryptoService;
using CryptoService.Interface;
using DAL;
using DAL.Concrete;
using DAL.Interface;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class DependencyResolver
    {
        /// <summary>
        /// The method for Kernel configuration
        /// </summary>
        /// <param name="kernel">this IKernel parameter</param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope(); ;
            kernel.Bind<DbContext>().To<SocialNetworkContext>().InRequestScope(); 
            kernel.Bind<IPasswordService>().To<PasswordService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IPhotoService>().To<PhotoService>();
        }
    }
}
