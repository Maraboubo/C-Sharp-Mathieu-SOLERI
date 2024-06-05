using Microsoft.Data.SqlClient;
using System.Data;


namespace Harmonium.Repository
{
    public class GenerateurConnexion : InterfaceConnexion
    {
        private readonly string _ligneDeConnexion;
        public GenerateurConnexion(string uneLigneDeConnexion)
        {
            _ligneDeConnexion = uneLigneDeConnexion;
        }
        public IDbConnection CreateConnexion()
        {
            return new SqlConnection(_ligneDeConnexion);
        }
    }
}
