using Harmonium.Models;
using Dapper;

namespace Harmonium.Repository
{
    public class UtilisateurRepository : InterfaceUtilisateurRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public UtilisateurRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Utilisateur> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            return connection.Query<Utilisateur>("SELECT * FROM Utilisateur");
        }
        public Utilisateur GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            return connection.QueryFirstOrDefault<Utilisateur>("SELECT * FROM Utilisateur WHERE id_Utilisateur = @id_Utilisateur", new { id_Utilisateur = id });
        }
        public void Add(Utilisateur utilisateur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            connection.Execute
                (
                "INSERT INTO Utilisateur(idStatut, id_vCode, uNom, uPrenom, Email, uIdentifiant, uMotDePasse, Adresse1)" +
                "VALUES (@idStatut, @id_vCode, @uNom, @uPrenom, @Email, @uIdentifiant, @uMotDePasse, @Adresse1)"
                , utilisateur);
        }
        public void Update(Utilisateur utilisateur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            connection.Execute
                (
                "UPDATE Utilisateur SET idStatut = @idStatut, id_vCode = @id_vCode, uNom = @uNom, uPrenom = @uPrenom, Email = @Email, uIdentifiant = @uIdentifiant, uMotDePasse = @uMotDePasse, Adresse1 = @Adresse1 WHERE id_Utilisateur = @id_Utilisateur"
                , utilisateur);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            connection.Execute("DELETE FROM Utilisateur WHERE id_Utilisateur = @id_Utilisateur", new { id_Utilisateur = id });
        }
    }
}
