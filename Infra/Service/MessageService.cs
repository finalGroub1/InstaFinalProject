using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class MessageService : ImessageService
    {
        private readonly ImessageRepository imessageRepository;

        public MessageService(ImessageRepository imessageRepository)
        {
            this.imessageRepository = imessageRepository;
        }

        public bool deleteMessage(int id)
        {
            return imessageRepository.deleteMessage(id);
        }

        public List<Message> getallMessage()
        {
            return imessageRepository.getallMessage();
        }

        public Message getbyidMessage(int id)
        {
            return imessageRepository.getbyidMessage(id);
        }

        public bool insertMessage(Message message)
        {
            return imessageRepository.insertMessage(message);
        }

        public bool updateMessage(Message message)
        {
            return imessageRepository.updateMessage(message);
        }
    }
}
