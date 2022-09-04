using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface ImessageRepository
    {
        public List<Message> getallMessage(int sender, int reciver);

        public bool updateMessage(Message message);

        public bool deleteMessage(int id);

        public bool insertMessage(Message message);

        public Message getbyidMessage(int id);
    }
}
