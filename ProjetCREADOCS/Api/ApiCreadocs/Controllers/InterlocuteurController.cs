using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/interlocuteur")]
    [ApiController]
    public class InterlocuteurController : ControllerBase
    {
        private readonly InterfaceInterlocuteurService _interfaceInterlocuteurService;
        public InterlocuteurController(InterfaceInterlocuteurService interfaceInterlocuteurService)
        {
            _interfaceInterlocuteurService = interfaceInterlocuteurService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Interlocuteur>> Get()
        {
            var interlocuteurs = _interfaceInterlocuteurService.GetAllInterlocuteurs();
            return Ok(interlocuteurs);
        }
        [HttpGet("{id}")]
        public ActionResult<Interlocuteur> Get(int id)
        {
            var interlocuteur = _interfaceInterlocuteurService.GetInterlocuteurById(id);
            if (interlocuteur == null)
            {
                return NotFound();
            }
            return Ok(interlocuteur);
        }

        //[HttpPost]
        //public ActionResult Post([FromBody] Interlocuteur interlocuteur)
        //{
        //    _interfaceInterlocuteurService.CreateInterlocuteur(interlocuteur);
        //    return CreatedAtAction(nameof(Get), new { id = interlocuteur.id_inter }, interlocuteur);
        //}

        //tentative de modification de la méthode post pour qu'elle retourne l'interlocuteur nouvellement créé.
        [HttpPost]
        public ActionResult<Interlocuteur> Post([FromBody] Interlocuteur interlocuteur)
        {
            var createdInterlocuteur = _interfaceInterlocuteurService.CreateInterlocuteur(interlocuteur);
            if (createdInterlocuteur == null)
            {
                return BadRequest("Error creating the Interlocuteur.");
            }
            return CreatedAtAction(nameof(Get), new { id = createdInterlocuteur.id_inter }, createdInterlocuteur);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Interlocuteur interlocuteur)
        {
            if (id != interlocuteur.id_inter)
            {
                return BadRequest();
            }
            _interfaceInterlocuteurService.UpdateInterlocuteur(interlocuteur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _interfaceInterlocuteurService.DeleteInterlocuteur(id);
            return NoContent();
        }

        //Implémentation de connexion
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginModel userLoginModel)
        {
            var user = _interfaceInterlocuteurService.GetUserByEmailAndPassword(userLoginModel.Email, userLoginModel.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

    }
}
