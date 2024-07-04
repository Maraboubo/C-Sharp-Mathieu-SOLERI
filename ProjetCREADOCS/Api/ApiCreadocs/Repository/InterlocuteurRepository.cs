using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class InterlocuteurRepository : InterfaceInterlocuteurRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public InterlocuteurRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Interlocuteur> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM INTERLOCUTEUR";
            return connection.Query<Interlocuteur>(requete);
        }
        public Interlocuteur GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM INTERLOCUTEUR WHERE id_inter = @id_inter";
            return connection.QueryFirstOrDefault<Interlocuteur>(requete, new { id_inter = id });
        }
        public void Add(Interlocuteur interlocuteur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            VerificationChampsExistants(interlocuteur);
            string requete = "INSERT INTO INTERLOCUTEUR(id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter)" +
                "VALUES (@id_titre, @id_agence, @loginInter, @mdpInter, @loginKwInter, @mdpKwInter, @nomInter, @prenomInter, @telInter, @mailInter)";
            connection.Execute
                (requete, interlocuteur);
        }
        public void Update(Interlocuteur interlocuteur)
        {
            VerificationDeChamps(interlocuteur);

            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "UPDATE INTERLOCUTEUR SET id_titre = @id_titre, id_agence = @id_agence, loginInter = @loginInter, mdpInter = @mdpInter, loginKwInter = @loginKwInter," +
                "mdpKwInter = @mdpKwInter, nomInter = @nomInter, prenomInter = @prenomInter, telInter = @telInter, mailInter = @mailInter WHERE id_inter = @id_inter";
            connection.Execute(requete, interlocuteur);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM INTERLOCUTEUR WHERE id_inter = @id_inter";
            connection.Execute(requete, new { id_inter = id });
        }

        public void VerificationDeChamps(Interlocuteur unInterlocuteur)
        {
            // Validation des données de l'utilisateur
            if (unInterlocuteur == null)
            {
                throw new ArgumentNullException(nameof(unInterlocuteur), "L'utilisateur ne peut pas être nul.");
            }

            if (unInterlocuteur.id_inter <= 0)
            {
                throw new ArgumentException("L'ID utilisateur doit être supérieur à 0.", nameof(unInterlocuteur.id_inter));
            }

            if (string.IsNullOrWhiteSpace(unInterlocuteur.nomInter))
            {
                throw new ArgumentException("Le nom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.nomInter));
            }

            if (string.IsNullOrWhiteSpace(unInterlocuteur.prenomInter))
            {
                throw new ArgumentException("Le prénom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.prenomInter));
            }

            if (string.IsNullOrWhiteSpace(unInterlocuteur.mailInter) || !IsValidEmail(unInterlocuteur.mailInter))
            {
                throw new ArgumentException("L'adresse email de l'utilisateur est invalide.", nameof(unInterlocuteur.mailInter));
            }
        }

        public void VerificationChampsExistants(Interlocuteur unInterlocuteur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "select count(*) as Count from INTERLOCUTEUR where mailInter = @mailInter";
            dynamic result = connection.Query(requete, unInterlocuteur).Single();
            int count = result.Count;
            if (count > 0)
            {
                throw new ArgumentException("L'adresse email de l'utilisateur existe déjà.", nameof(unInterlocuteur.mailInter));
            }
        }

        private bool IsValidEmail(string email)
        {
            //Validation du champ mail
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
