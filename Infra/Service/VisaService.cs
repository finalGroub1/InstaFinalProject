using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
   public class VisaService : IVisaService
    {
        private readonly IVisaRepository visaRepository;

        public VisaService(IVisaRepository visaRepository)
        {
            this.visaRepository = visaRepository;
        }

        public bool deleteVisa(int id)
        {
            return visaRepository.deleteVisa(id);
        }

        public List<Visa> getallVisa(int id)
        {
            return visaRepository.getallVisa(id);
        }
        public bool Chickvisa(Visa visa)
        {
            return visaRepository.Chickvisa(visa);
        }

        public Visa getbyidVisa(int id)
        {
            return visaRepository.getbyidVisa(id);
        }

        public bool insertVisa(Visa visa)
        {
            return visaRepository.insertVisa(visa);
        }

        public bool updateVisa(Visa visa)
        {
            return visaRepository.updateVisa(visa);
        }
    }
}
