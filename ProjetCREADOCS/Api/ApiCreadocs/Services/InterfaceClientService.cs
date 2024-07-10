using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceClientService
    {
        Client CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName);
    }
}
