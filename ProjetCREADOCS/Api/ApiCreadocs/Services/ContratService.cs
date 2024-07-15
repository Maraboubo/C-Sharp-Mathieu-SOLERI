using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class ContratService : InterfaceContratService
    {
        private readonly InterfaceContratRepository _interfaceContratRepository;
        public ContratService(InterfaceContratRepository interfaceContratRepository)
        {
            _interfaceContratRepository = interfaceContratRepository;
        }
        public IEnumerable<Contrat> GetAllContrats()
        {
            return _interfaceContratRepository.GetAll();
        }
        public ContratAssur GetContratById(int id)
        {
            return _interfaceContratRepository.GetById(id);
        }
        public int CreateContrat(Contrat contrat)
        {
            return _interfaceContratRepository.Add(contrat);
        }

        public void UpdateContrat(Contrat contrat)
        {
            _interfaceContratRepository.Update(contrat);
        }

        public void DeleteContrat(int id)
        {
            _interfaceContratRepository.Delete(id);
        }
    }
}
