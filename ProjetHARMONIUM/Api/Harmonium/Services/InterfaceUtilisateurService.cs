using Harmonium.Models;

namespace Harmonium.Services
{
    public interface InterfaceUtilisateurService
    {
        IEnumerable<Utilisateur> GetAllUtilisateurs();
        Utilisateur GetUtilisateurById(int id);
        void CreateUtilisateur(Utilisateur utilisateur);
        void UpdateUtilisateur(Utilisateur utilisateur);
        void DeleteUtilisateur(int id);
    }
}
