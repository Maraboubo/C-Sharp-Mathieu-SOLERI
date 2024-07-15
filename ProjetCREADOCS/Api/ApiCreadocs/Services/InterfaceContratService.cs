using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceContratService
    {
        IEnumerable<Contrat> GetAllContrats();
        ContratAssur GetContratById(int id);
        int CreateContrat(Contrat contrat);
        void UpdateContrat(Contrat contrat);
        void DeleteContrat(int id);
    }
}
