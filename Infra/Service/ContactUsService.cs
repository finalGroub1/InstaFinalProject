using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            this.contactUsRepository = contactUsRepository;
        }

        public bool deleteContact(int id)
        {
            return contactUsRepository.deleteContact(id);
        }

        public List<Contactus> getallContact()
        {
            return contactUsRepository.getallContact();
        }

        public Contactus getbyidContact(int id)
        {
            return contactUsRepository.getbyidContact(id);
        }

        public bool insertContact(Contactus contactus)
        {
            return contactUsRepository.insertContact(contactus);
        }

        public bool updateContact(Contactus contactus)
        {
            return contactUsRepository.updateContact(contactus);
        }
    }
}
