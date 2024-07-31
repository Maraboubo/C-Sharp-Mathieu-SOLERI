using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class InterlocuteurService : InterfaceInterlocuteurService
    {
        private readonly InterfaceInterlocuteurRepository _interfaceInterlocuteurRepository;
        public InterlocuteurService(InterfaceInterlocuteurRepository interfaceInterlocuteurRepository)
        {
            _interfaceInterlocuteurRepository = interfaceInterlocuteurRepository;
        }
        public IEnumerable<Interlocuteur> GetAllInterlocuteurs()
        {
            return _interfaceInterlocuteurRepository.GetAll();
        }
        public Interlocuteur GetInterlocuteurById(int id)
        {
            return _interfaceInterlocuteurRepository.GetById(id);
        }

        //public void CreateInterlocuteur(Interlocuteur interlocuteur)
        //{
        //    _interfaceInterlocuteurRepository.Add(interlocuteur);
        //}
        public Interlocuteur CreateInterlocuteur(Interlocuteur interlocuteur)
        {
            return _interfaceInterlocuteurRepository.Add(interlocuteur);
        }

        public void UpdateInterlocuteur(Interlocuteur interlocuteur)
        {
            _interfaceInterlocuteurRepository.Update(interlocuteur);
        }

        //public void UpdateInterlocuteur(Interlocuteur interlocuteur)
        //{
        //    _interfaceInterlocuteurRepository.Update(interlocuteur);
        //}

        public void DeleteInterlocuteur(int id)
        {
            _interfaceInterlocuteurRepository.Delete(id);
        }

        //Implémentation de fonctionnalité connexion
        public Interlocuteur GetUserByEmailAndPassword(string email, string password)
        {
            return _interfaceInterlocuteurRepository.GetPass(email, password);
        }

    }
}
