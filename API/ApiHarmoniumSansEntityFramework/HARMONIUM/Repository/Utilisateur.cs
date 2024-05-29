using HARMONIUM.Models;
using HARMUNIUM.repository;
using Dapper;
namespace HARMONIUM.Repository
{
    //public interface IUtilisateurRepository
    //{
    //    IEnumerable<Utilisateur> GetAll();
    //    Utilisateur GetById(int id);
    //    void Add(Utilisateur utilisateur);
    //    void Delete(int id);
    //}

    //public class UtilisateurRepository : IUtilisateurRepository
    //{
    //    private readonly IDbConnectionFactory _dbConnectionFactory;

    //    public UtilisateurRepository(IDbConnectionFactory dbConnectionFactory)
    //    {
    //        _dbConnectionFactory = dbConnectionFactory;
    //    }

    //    public IEnumerable<Utilisateur> GetAll()
    //    {
    //        using var connection = _dbConnectionFactory.CreateConnection();
    //        return connection.Query<Utilisateur>("SELECT * FROM Utilisateur");
    //    }
    //    public Utilisateur GetById(int id)
    //    {
    //        using var connection = _dbConnectionFactory.CreateConnection();
    //        return connection.QueryFirstOrDefault<Utilisateur>("\"SELECT * FROM Utilisateur WHERE id_Utilisateur = @id_Utilisateur\", new { Id = id }");
    //    }
    //    public void Add(Utilisateur utilisateur)
    //    {
    //        using var connection = _dbConnectionFactory.CreateConnection();
    //        connection.Execute
    //            (
    //            "INSERT INTO Utilisateur(id_Utilisateur, idStatut, id_vCode, uNom, uPrenom, Email, uIdentifiant, uMotDePasse, Adresse1)" +
    //            "VALUES (@id_Utilisateur, @idStatut, @id_vCode, @uNom, @uPrenom, @Email, @uIdentifiant, @uMotDePasse, @Adresse1)"
    //            , utilisateur);
    //    }
    //    public void Update(Utilisateur utilisateur)
    //    {
    //        using var connection = _dbConnectionFactory.CreateConnection();
    //        connection.Execute
    //            (
    //            "UPDATE Utilisateur SET id_Utilisateur = @id_Utilisateur, idStatut = @idStatut, id_vCode = @id_vCode, uNom = @uNom, uPrenom = @uPrenom, Email = @Email, uIdentifiant = @uIdentifiant, uMotDePasse = @uMotDePasse, Adresse1 = @Adresse1 WHERE Id = @Id"
    //            , utilisateur);
    //    }

    //    public void Delete(int id)
    //    {
    //        using var connection = _dbConnectionFactory.CreateConnection();
    //        connection.Execute("DELETE FROM Utilisateur WHERE Id = @Id", new { Id = id });
    //    }
    //}
}
