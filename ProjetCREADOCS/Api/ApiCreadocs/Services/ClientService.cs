using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class ClientService : InterfaceClientService
    {
        private readonly InterfaceClientRepository _clientRepository;
        private readonly InterfaceVilleRepository _villeRepository;
        private readonly InterfacePaysRepository _paysRepository;
        public ClientService(InterfaceClientRepository clientRepository, InterfaceVilleRepository villeRepository, InterfacePaysRepository paysRepository)
        {
            _clientRepository = clientRepository;
            _villeRepository = villeRepository;
            _paysRepository = paysRepository;
        }

        public Client CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName)
        {
            var existingClient = _clientRepository.GetClientByNumId(client.numIdCli);
            if (existingClient != null)
            {
                return existingClient;
            }

            _paysRepository.GetOrCreateCountry(countryCode, countryName);
            int cityId = _villeRepository.GetOrCreateCity(postalCode, placeName, countryCode);
            client.id_ville = cityId;

            int clientId = _clientRepository.AddClient(client);
            client.id_Cli = clientId;

            return client;
        }

        //Création de nouveau client sans recherche d'existant.

        //public Client CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName)
        //{
        //    _paysRepository.GetOrCreateCountry(countryCode, countryName);
        //    int cityId = _villeRepository.GetOrCreateCity(postalCode, placeName, countryCode);
        //    client.id_ville = cityId;

        //    int clientId = _clientRepository.AddClient(client);
        //    client.id_Cli = clientId;

        //    return client;
        //}
    }
}
