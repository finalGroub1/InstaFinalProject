using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IHomeRepository
    {
        public List<Home> getallHome();

        public bool updateHome(Home home);

        public bool deleteHome(int id);

        public bool insertHome(Home home);

        public Home getbyidHome(int id);
    }
}
