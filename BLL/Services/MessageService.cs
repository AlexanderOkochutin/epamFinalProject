using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface;
using ORM.Entities;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork uow;
       
        public MessageService(IUnitOfWork uow)
        {
            this.uow = uow;
       
        }
        public void AddMessage(BllMessage message)
        {
           uow.Messages.Create(message.ToBllMessage());
            uow.Commit();
        }

        public void DeleteMessage(BllMessage message)
        {
            uow.Messages.Delete(message.Id);
            uow.Commit();
        }

        public List<BllMessage> GetMessages(int UserFrom, int UserTo)
        {
           var temp = uow.Messages.GetMessages(UserFrom, UserTo);
           return MessageMapper.Map(temp).ToList();
        }

        public void UpdateMessage(BllMessage message)
        {
            uow.Messages.Update(message.ToBllMessage());
        }
    }
}
