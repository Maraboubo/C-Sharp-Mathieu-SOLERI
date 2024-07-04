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

        [HttpPost]
        public ActionResult Post([FromBody] Interlocuteur interlocuteur)
        {
            _interfaceInterlocuteurService.CreateInterlocuteur(interlocuteur);
            return CreatedAtAction(nameof(Get), new { id = interlocuteur.id_inter }, interlocuteur);
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
    }
}
