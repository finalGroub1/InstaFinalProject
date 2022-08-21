using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface IInteractionRepository
    {
        public List<Interaction> getallInterAction();

        public bool updateInterAction(Interaction Interaction);

        public bool deleteInterAction(int id);

        public bool insertInterAction(Interaction Interaction);

        public Interaction getbyidInterAction(int id);
    }
}
