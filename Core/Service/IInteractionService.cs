using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IInteractionService
    {
        public List<Interaction> getallInterAction();

        public bool updateInterAction(Interaction Interaction);

        public bool deleteInterAction(int id);

        public bool insertInterAction(Interaction Interaction);

        public Interaction getbyidInterAction(int id);
    }
}
