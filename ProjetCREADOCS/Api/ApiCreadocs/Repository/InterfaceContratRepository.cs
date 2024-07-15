using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceContratRepository
    {
        IEnumerable<Contrat> GetAll();
        ContratAssur GetById(int id);
        int Add(Contrat contrat);
        void Update(Contrat contrat);
        void Delete(int id);
    }
}
