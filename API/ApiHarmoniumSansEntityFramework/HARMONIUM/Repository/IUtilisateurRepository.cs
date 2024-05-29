using HARMONIUM.Models;

namespace HARMONIUM.Repository
{
    public interface IUtilisateurRepository
    {
        IEnumerable<Utilisateur> GetAll();
        Utilisateur GetById(int id);
        void Add(Utilisateur utilisateur);
        void Update(Utilisateur utilisateur);
        void Delete(int id);
    }
}
