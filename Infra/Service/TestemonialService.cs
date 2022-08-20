using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class TestemonialService : ITestemonialService
    {
        private readonly ITestemonialRepository testemonialRepository;

        public TestemonialService(ITestemonialRepository testemonialRepository)
        {
            this.testemonialRepository = testemonialRepository;
        }

        public bool deleteTestemonial(int id)
        {
            return testemonialRepository.deleteTestemonial(id);
        }

        public List<Testmonial> getallTestemonial()
        {
            return testemonialRepository.getallTestemonial();
        }

        public Testmonial getbyidTestemonial(int id)
        {
            return testemonialRepository.getbyidTestemonial(id);
        }

        public bool insertTestemonial(Testmonial testmonial)
        {
            return testemonialRepository.insertTestemonial(testmonial);
        }

        public bool updateTestemonial(Testmonial testmonial)
        {
            return testemonialRepository.updateTestemonial(testmonial);
        }
    }
}
