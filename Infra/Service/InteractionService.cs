using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository interactionRepository;

        public InteractionService(IInteractionRepository interactionRepository)
        {
            this.interactionRepository = interactionRepository;
        }

        public bool deleteInterAction(int id)
        {
            return interactionRepository.deleteInterAction(id);
        }

        public List<Interaction> getallInterAction()
        {
            return interactionRepository.getallInterAction();
        }

        public Interaction getbyidInterAction(int id)
        {
            return interactionRepository.getbyidInterAction(id);
        }

        public bool insertInterAction(Interaction Interaction)
        {
            return interactionRepository.insertInterAction(Interaction);
        }

        public bool updateInterAction(Interaction Interaction)
        {
            return interactionRepository.updateInterAction(Interaction);
        }
    }
}
