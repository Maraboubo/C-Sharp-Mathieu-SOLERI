using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class ContratRepository : InterfaceContratRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public ContratRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Contrat> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM CONTRAT";
            return connection.Query<Contrat>(requete);
        }
        public ContratAssur GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT id_Contr, CONTRAT.id_TypContr, typContr, id_inter, id_Cli, CONTRAT.id_Assu, nomAssu, valeurAssu, dateContr, dateDebutContr, dateFinContr FROM CONTRAT " +
                "INNER JOIN TYPE_CONTRAT ON CONTRAT.id_typContr = TYPE_CONTRAT.id_typContr " +
                "INNER JOIN ASSURANCE ON CONTRAT.id_Assu = ASSURANCE.id_Assu" +
                " WHERE id_Contr = @id_Contr;";
            return connection.QueryFirstOrDefault<ContratAssur>(requete, new { id_Contr = id });
        }

        //Incrémentation de la fonctionalité d'ajout de contrat afin qu'elle retourne toutes les informations de CONTRAT ainsi que ASSURANCE.
        public int Add(Contrat contrat)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = @"
        INSERT INTO CONTRAT(id_typContr, numCarte, id_inter, id_Cli, id_Assu, id_mutu, numSim, dateContr, dateDebutContr, dateFinContr, fichierContr) 
        VALUES (@id_typContr, @numCarte, @id_inter, @id_Cli, @id_Assu, @id_mutu, @numSim, @dateContr, @dateDebutContr, @dateFinContr, @fichierContr);
        SELECT CAST(SCOPE_IDENTITY() as int)";
            return connection.QueryFirstOrDefault<int>(requete, contrat);
        }

        public void Update(Contrat contrat)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "UPDATE CONTRAT SET id_typContr = @id_typContr, numCarte = @numCarte, id_inter = @id_inter, id_Cli = @id_Cli, id_Assu = @id_Assu, id_mutu = @id_mutu, numSim = @numSim, dateContr = @dateContr, dateDebutContr = @dateDebutContr, dateFinContr = @dateFinContr, fichierContr = @fichierContr";
            connection.Execute(requete, contrat);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM CONTRAT WHERE id_Contr = @id_Contr";
            connection.Execute(requete, new { id_Contr = id });
        }

        //public void VerificationDeChamps(Interlocuteur unInterlocuteur)
        //{
        //    // Validation des données de l'utilisateur
        //    if (unInterlocuteur == null)
        //    {
        //        throw new ArgumentNullException(nameof(unInterlocuteur), "L'utilisateur ne peut pas être nul.");
        //    }

        //    if (unInterlocuteur.id_inter <= 0)
        //    {
        //        throw new ArgumentException("L'ID utilisateur doit être supérieur à 0.", nameof(unInterlocuteur.id_inter));
        //    }

        //    if (string.IsNullOrWhiteSpace(unInterlocuteur.nomInter))
        //    {
        //        throw new ArgumentException("Le nom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.nomInter));
        //    }

        //    if (string.IsNullOrWhiteSpace(unInterlocuteur.prenomInter))
        //    {
        //        throw new ArgumentException("Le prénom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.prenomInter));
        //    }

        //    if (string.IsNullOrWhiteSpace(unInterlocuteur.mailInter) || !IsValidEmail(unInterlocuteur.mailInter))
        //    {
        //        throw new ArgumentException("L'adresse email de l'utilisateur est invalide.", nameof(unInterlocuteur.mailInter));
        //    }
        //}

        //public void VerificationChampsExistants(Interlocuteur unInterlocuteur)
        //{
        //    using var connection = _interfaceConnection.CreateConnexion();
        //    string requete = "select count(*) as Count from INTERLOCUTEUR where mailInter = @mailInter";
        //    dynamic result = connection.Query(requete, unInterlocuteur).Single();
        //    int count = result.Count;
        //    if (count > 0)
        //    {
        //        throw new ArgumentException("L'adresse email de l'utilisateur existe déjà.", nameof(unInterlocuteur.mailInter));
        //    }
        //}

        //private bool IsValidEmail(string email)
        //{
        //    //Validation du champ mail
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
