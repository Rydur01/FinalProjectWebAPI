using FinalProjectWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly FoodContext _context;

        public PersonController(ILogger<PersonController> logger, FoodContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                if (_context.People == null || !_context.People.Any())
                    return NotFound("No People found in the database");
                return Ok(_context.People?.ToList());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet]
        [Route("ById")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int ID)
        {
            try
            {
                var person = _context.People?.Find(ID);
                if (person == null)
                {
                    return NotFound("The requested resource was not found");
                }
                if (ID == null || ID == 0)
                {
                    return Ok(_context.People?.Take(5));
                }
                return Ok(person);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int ID)
        {
            try
            {
                var person = _context.People?.Find(ID);
                if (person == null)
                {
                    return NotFound($"Person with id {ID} was not found");
                }
                _context.People?.Remove(person);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok("Delete operation was successful");
                }
                return Problem("Delete was not successful. Please try again");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Add(Person personToAdd)
        {
            //what if they provide an id?
            if (personToAdd.ID != 0)
            {
                return BadRequest("ID was provided but not needed");
            }
            //1.) Fix it and don't tell and just do it
            //2.) Tell them to fix it
            try
            {
                //personToAdd.Id = 0;
                _context.People?.Add(personToAdd);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok($"Person {personToAdd.Name} added successfully");
                }
                return Problem("Add was not successful. Please try again");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Put(Person personToEdit)
        {
            if (personToEdit.ID < 1)
            {
                return BadRequest("Please provide a valid id");
            }
            try
            {
                var person = _context.People?.Find(personToEdit.ID);
                if (person == null)
                    return NotFound("The person was not found");
                person.Name = personToEdit.Name;
                person.Birthday = personToEdit.Birthday;
                person.Program = personToEdit.Program;
                person.Year = personToEdit.Year;
                _context.People?.Update(person);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok("Person edited successfully");
                }
                return Problem("Edit was not successful. Please try again");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}