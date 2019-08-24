using HTTPVerbs.Services;
using Microsoft.AspNetCore.Mvc;
using HTTPVerbs.Model;

namespace HTTPVerbs.Controllers
{
    [Produces("application/json")]
    [Route("api/Persons")]
    public class PersonsController : Controller
    {

        private IPersonService _personService { get; set; }
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }



        // GET: api/Persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FingAll());
        }


        // GET: api/Persons/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Person person = _personService.FindById(id);
            if (person.Equals(null))
            {
                return NotFound();
            }

            return Ok(person);
        }
        

        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }
        

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }
        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
