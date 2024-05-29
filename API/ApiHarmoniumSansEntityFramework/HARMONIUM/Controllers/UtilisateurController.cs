using HARMONIUM.Models;
using HARMONIUM.Services;

using Microsoft.AspNetCore.Mvc;


namespace HARMONIUM.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Utilisateur>> Get()
        {
            var utilisateurs = _utilisateurService.GetAllUtilisateurs();
            return Ok(utilisateurs);
        }

        [HttpGet("{id}")]
        public ActionResult<Utilisateur> Get(int id)
        {
            var utilisateur = _utilisateurService.GetUtilisateurById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return Ok(utilisateur);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Utilisateur utilisateur)
        {
            _utilisateurService.CreateUtilisateur(utilisateur);
            return CreatedAtAction(nameof(Get), new { id = utilisateur.id_Utilisateur }, utilisateur);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Utilisateur utilisateur)
        {
            if (id != utilisateur.id_Utilisateur)
            {
                return BadRequest();
            }
            _utilisateurService.UpdateUtilisateur(utilisateur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _utilisateurService.DeleteUtilisateur(id);
            return NoContent();
        }
    }
}
