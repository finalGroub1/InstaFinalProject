using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IAboutUsRepository
    {
        public List<Aboutus> getallAbout();

        public bool updateAbout(Aboutus aboutus);

        public bool deleteAbout(int id);

        public bool insertAbout(Aboutus aboutus);

        public Aboutus getbyidAbout(int id);
    }
}
