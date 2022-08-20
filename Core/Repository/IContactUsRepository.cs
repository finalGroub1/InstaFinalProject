using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IContactUsRepository
    {
        public List<Contactus> getallContact();

        public bool updateContact(Contactus contactus);

        public bool deleteContact(int id);

        public bool insertContact(Contactus contactus);

        public Contactus getbyidContact(int id);
    }
}
