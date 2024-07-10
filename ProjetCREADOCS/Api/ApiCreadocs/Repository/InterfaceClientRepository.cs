using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceClientRepository
    {
        int AddClient(Client client);
        Client GetClientByNumId(string numIdCli);
    }
}
