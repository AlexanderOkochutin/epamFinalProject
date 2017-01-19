using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class MessageMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static BllMessage ToBllMessage(this DalMessage message)
        {
            if (ReferenceEquals(message, null)) return null;
            BllMessage result = new BllMessage()
            {
               Id = message.Id,
               Date = message.Date,
               Text = message.Text,
               ProfileIdFrom = message.ProfileIdFrom,
               ProfileIdTo = message.ProfileIdTo
            };
            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static DalMessage ToBllMessage(this BllMessage message)
        {
            if (ReferenceEquals(message, null)) return null;
            DalMessage result = new DalMessage()
            {
                Id = message.Id,
                Date = message.Date,
                Text = message.Text,
                ProfileIdFrom = message.ProfileIdFrom,
                ProfileIdTo = message.ProfileIdTo
            };
            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<BllMessage> Map(IEnumerable<DalMessage> messages)
        {
            var bllMessages = new List<BllMessage>();
            foreach (var item in messages)
            {
                bllMessages.Add(item.ToBllMessage());
            }
            return bllMessages;
        }
    }
}
