using System.Data;

namespace Harmonium.Repository
{
    public interface InterfaceConnexion
    {
        IDbConnection CreateConnexion();
    }
}
