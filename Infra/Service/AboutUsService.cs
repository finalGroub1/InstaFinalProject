using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class AboutUsService : IAboutUsService
    {
        private readonly IAboutUsRepository aboutUsRepository;

        public AboutUsService(IAboutUsRepository aboutUsRepository)
        {
            this.aboutUsRepository = aboutUsRepository;
        }

        public bool deleteAbout(int id)
        {
            return aboutUsRepository.deleteAbout(id);
        }

        public List<Aboutus> getallAbout()
        {
            return aboutUsRepository.getallAbout();
        }

        public Aboutus getbyidAbout(int id)
        {
            return aboutUsRepository.getbyidAbout(id);
        }

        public bool insertAbout(Aboutus aboutus)
        {
            return aboutUsRepository.insertAbout(aboutus);
        }

        public bool updateAbout(Aboutus aboutus)
        {
            return aboutUsRepository.updateAbout(aboutus);
        }
    }
}
