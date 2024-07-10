using ApiCreadocs.Models;
using Dapper;
using System.Data;
using System.Data.Common;

namespace ApiCreadocs.Repository
{
    public class ClientRepository : InterfaceClientRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;

        public ClientRepository(InterfaceConnexion connection)
        {
            _interfaceConnection = connection;
        }

        public int AddClient(Client client)
        {
            using var connection = _interfaceConnection.CreateConnexion();

            string query = @"INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
                         VALUES (@id_sexe, @id_ville, @id_regimeSecu, @nomCli, @prenomCli, @numIdCli, @telCli, @mailCli, @depNaissCli, @dateNaissCli, @add1Cli, @add2Cli, @add3Cli, @numCompteCli, @numSecuCli);
                         SELECT CAST(SCOPE_IDENTITY() as int)";
            return connection.QueryFirstOrDefault<int>(query, client);
        }

        //Insertion de la vérification de l'existence du client par son numéro d'identification.
        public Client GetClientByNumId(string numIdCli)
        {
            using var connection = _interfaceConnection.CreateConnexion();

            string query = "SELECT * FROM CLIENTS WHERE numIdCli = @NumIdCli";
            return connection.QueryFirstOrDefault<Client>(query, new { NumIdCli = numIdCli });
        }
    }
}
