using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IContactUsService
    {
        public List<Contactus> getallContact();

        public bool updateContact(Contactus contactus);

        public bool deleteContact(int id);

        public bool insertContact(Contactus contactus);

        public Contactus getbyidContact(int id);
    }
}
