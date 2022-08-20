using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface IHomeService
    {
        public List<Home> getallHome();

        public bool updateHome(Home home);

        public bool deleteHome(int id);

        public bool insertHome(Home home);

        public Home getbyidHome(int id);
    }
}
