using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface ImessageService
    {
        public List<Message> getallMessage();

        public bool updateMessage(Message message);

        public bool deleteMessage(int id);

        public bool insertMessage(Message message);

        public Message getbyidMessage(int id);
    }
}
