﻿using HARMONIUM.Models;

namespace HARMONIUM.Services
{   
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAllUtilisateurs();
        Utilisateur GetUtilisateurById(int id);
        void CreateUtilisateur(Utilisateur utilisateur);
        void UpdateUtilisateur(Utilisateur utilisateur);
        void DeleteUtilisateur(int id);
    }
}
