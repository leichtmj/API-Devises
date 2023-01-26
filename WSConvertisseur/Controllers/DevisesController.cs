using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        public List<Devise> lesDevises = new List<Devise>();



        public DevisesController()
        {
            lesDevises.Add(new Devise(1, "Dollar", 1.08));
            lesDevises.Add(new Devise(2, "Franc Suisse", 1.07));
            lesDevises.Add(new Devise(3, "Yen", 120));
        }
        /// <summary>
        /// Récupère toutes les devises
        /// </summary>
        /// <returns></returns>
        // GET: api/<DevisesController>
        [HttpGet]
        [ProducesResponseType(200)]

        public IEnumerable<Devise> GetAll()
        {
            return lesDevises;
        }

        /// <summary>
        /// Récupère une devise via son id
        /// </summary>
        /// <param name="id">L'id de la devise</param>
        /// <response code ="200">quand la devise est trouvée</response>
        /// <response code ="404">quand la devise n'est pas trouvée</response>
        /// <returns>Http response</returns>
        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise = lesDevises.FirstOrDefault((d) => d.Id == id); 
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        /// <summary>
        /// Ajoute une devise
        /// </summary>
        /// <param name="devise"></param>
        /// <response code ="400">quand la devise n'est pas trouvée</response>
        /// <response code ="201">quand la devise est ok</response>
        /// <returns>Retourne la devise créée</returns>
        // POST api/<DevisesController>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]


        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            lesDevises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Permet la modification d'une devise
        /// </summary>
        /// <param name="id">L'id de la devise que l'on souhaite modifier</param>
        /// <param name="devise">La nouvelle devise modifiée</param>
        /// <response code ="404">quand la devise n'est pas trouvée</response>
        /// <response code ="400">quand la devise est invalide</response>
        /// <response code ="204">quand la modification a été appliquée</response>
        /// <returns></returns>
        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]


        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = lesDevises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            lesDevises[index] = devise;
            return NoContent();

        }

        /// <summary>
        /// Supprime une devise à partir de son ID
        /// </summary>
        /// <param name="id">L'id de la devise à supprimer</param>
        /// <response code ="400">quand la devise est invalide</response>
        /// <returns>La devise supprimée</returns>
        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? devise = lesDevises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            lesDevises.Remove(devise);

            return devise;
        }

    }
}
