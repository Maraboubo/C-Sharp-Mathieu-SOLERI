using Harmonium.Models;

namespace Harmonium.Repository
{
    public interface InterfaceInscriptionUtilisateur
    {
        IEnumerable<InsriptionUtilisateur> GetAll();
        Utilisateur GetById(int id);
        void Add(Utilisateur utilisateur);
        void Update(Utilisateur utilisateur);
        void Delete(int id);
    }
}
