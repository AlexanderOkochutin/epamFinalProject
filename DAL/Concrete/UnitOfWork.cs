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
        public IProfileRepository Profiles { get; set; }
        public IPhotoRepository Photos { get; set; }
        public IMessageRepository Messages { get; set; }
        public IInviteRepository Invites { get; set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
            Users = new UserRepository((SocialNetworkContext)context);
            Photos = new PhotoRepository((SocialNetworkContext) context);
            Profiles = new ProfileRepository((SocialNetworkContext) context);
            Messages = new MessageRepository((SocialNetworkContext) context);
            Invites = new InviteRepository((SocialNetworkContext)context);
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
