using ApiCreadocs.Models;
using ApiCreadocs.Services;
using ApiCreadocs.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly InterfaceClientService _clientService;

        public ClientController(InterfaceClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public ActionResult<Client> Post([FromBody] ClientCreationDto clientCreationDto)
        {
            var createdClient = _clientService.CreateClient(
                clientCreationDto.Client,
                clientCreationDto.postalCode,
                clientCreationDto.placeName,
                clientCreationDto.countryCode,
                clientCreationDto.countryName);

            if (createdClient.id_Cli != clientCreationDto.Client.id_Cli) // Si le client existait déjà
            {
                return Ok(createdClient);
            }

            return CreatedAtAction(nameof(Get), new { id = createdClient.id_Cli }, createdClient);
        }

        //Création client sans vérification d'existant

        //[HttpPost]
        //public ActionResult<Client> Post([FromBody] ClientCreationDto clientCreationDto)
        //{
        //    var createdClient = _clientService.CreateClient(
        //        clientCreationDto.Client,
        //        clientCreationDto.postalCode,
        //        clientCreationDto.placeName,
        //        clientCreationDto.countryCode,
        //        clientCreationDto.countryName);

        //    return CreatedAtAction(nameof(Get), new { id = createdClient.id_Cli }, createdClient);
        //}

        //[HttpPost]
        //public ActionResult<Client> Post([FromBody] Client client, [FromQuery] string postalCode, [FromQuery] string placeName, [FromQuery] string countryCode, [FromQuery] string countryName)
        //{
        //    var createdClient = _clientService.CreateClient(client, postalCode, placeName, countryCode, countryName);
        //    return CreatedAtAction(nameof(Get), new { id = createdClient.id_Cli }, createdClient);
        //}

        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            // Implémenter la logique pour récupérer le client par ID
            return Ok(); // Placeholder
        }
    }
}
