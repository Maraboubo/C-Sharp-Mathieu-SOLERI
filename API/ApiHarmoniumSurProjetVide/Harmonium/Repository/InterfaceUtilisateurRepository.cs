using Harmonium.Models;

namespace Harmonium.Repository
{
    public interface InterfaceUtilisateurRepository
    {
        IEnumerable<Utilisateur>GetAll();
        Utilisateur GetById(int id);
        void Add(Utilisateur utilisateur);
        void Update(Utilisateur utilisateur);
        void Delete(int id);
    }
}
