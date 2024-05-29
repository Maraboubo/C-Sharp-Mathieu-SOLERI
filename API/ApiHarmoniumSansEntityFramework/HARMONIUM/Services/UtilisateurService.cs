using HARMONIUM.Repository;
using HARMONIUM.Models;

namespace HARMONIUM.Services;

public class UtilisateurService : IUtilisateurService
{
    private readonly IUtilisateurRepository _utilisateurRepository;

    public UtilisateurService(IUtilisateurRepository utilisateurRepository)
    {
        _utilisateurRepository = utilisateurRepository;
    }

    public IEnumerable<Utilisateur> GetAllUtilisateurs()
    {
        return _utilisateurRepository.GetAll();
    }

    public Utilisateur GetUtilisateurById(int id)
    {
        return _utilisateurRepository.GetById(id);
    }

    public void CreateUtilisateur(Utilisateur utilisateur)
    {
        _utilisateurRepository.Add(utilisateur);
    }

    public void UpdateUtilisateur(Utilisateur utilisateur)
    {
        _utilisateurRepository.Update(utilisateur);
    }

    public void DeleteUtilisateur(int id)
    {
        _utilisateurRepository.Delete(id);
    }
}
