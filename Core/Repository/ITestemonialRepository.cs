using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface ITestemonialRepository
    {
        public List<Testmonial> getallTestemonial();

        public bool updateTestemonial(Testmonial testmonial);

        public bool deleteTestemonial(int id);

        public bool insertTestemonial(Testmonial testmonial);

        public Testmonial getbyidTestemonial(int id);
    }
}
