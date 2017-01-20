using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// User collection
        /// </summary>
        IUserRepository Users { get; set; }
        IProfileRepository Profiles { get; set; }
        IPhotoRepository Photos { get; set; }
        IMessageRepository Messages { get; set; }
        IInviteRepository Invites { get; set; }
        void Commit();
        //Rollback
    }
}
