using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IMessageService
    {
        void AddMessage(BllMessage message);
        void DeleteMessage(BllMessage message);
        List<BllMessage> GetMessages(int UserFrom, int UserTo);
        void UpdateMessage(BllMessage message);
    }
}
