using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface IVisaRepository
    {
        public List<Visa> getallVisa();

        public bool updateVisa(Visa visa);

        public bool deleteVisa(int id);

        public bool insertVisa(Visa visa);

        public Visa getbyidVisa(int id);
    }
}
