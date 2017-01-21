using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.DTO;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> Profiles;
        private readonly DbSet<Message> Messages;

        public MessageRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            Profiles = socialNetworkContext.Profiles;
            Messages = socialNetworkContext.Messages;
        }

        public void Create(DalMessage dalMessage)
        {
            var message = dalMessage.ToMessage();
            var profileFrom = Profiles.FirstOrDefault(p=>p.Id==dalMessage.ProfileIdFrom);
            var profileTo = Profiles.FirstOrDefault(p => p.Id == dalMessage.ProfileIdTo);
            message.ProfileFrom = profileFrom;
            message.ProfileTo = profileTo;
            Messages.Add(message);
        }

        public void Delete(int id)
        {
            Messages.Remove(Messages.FirstOrDefault(m => m.Id == id));

        }

        public DalMessage Get(int id)
        {
           return Messages.FirstOrDefault(m => m.Id == id).ToDalMessage();
        }

        public IEnumerable<DalMessage> GetAll()
        {
            return Messages.Include(m => m.ProfileFrom).Include(m => m.ProfileTo).Select(m => m).Map();
        }

        public DalMessage GetByPredicate(Expression<Func<DalMessage, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalMessage entity)
        {
            throw new NotImplementedException();
        }

        public List<DalMessage> GetMessages(int ProfileFrom, int ProfileTo)
        {
            return
                Messages.Where(m => (m.ProfileFrom.Id == ProfileFrom && m.ProfileTo.Id == ProfileTo) || (m.ProfileFrom.Id == ProfileTo && m.ProfileTo.Id == ProfileFrom))
                    .OrderBy(m => m.Date)
                    .Map().ToList();
        }
    }
}
