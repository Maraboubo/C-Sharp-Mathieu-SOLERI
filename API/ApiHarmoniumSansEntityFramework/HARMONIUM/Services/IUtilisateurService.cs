using HARMONIUM.Models;

namespace HARMONIUM.Services
{   
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAllUtilisateurs();
        Utilisateur GetUtilisateurById(int id);
        void CreateUtilisateur(Utilisateur song);
        void UpdateUtilisateur(Utilisateur song);
        void DeleteUtilisateur(int id);
    }
}
