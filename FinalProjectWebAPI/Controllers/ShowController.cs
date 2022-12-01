using FinalProjectWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProjectWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly ILogger<ShowController> _logger;
        private readonly ShowsContext _context;

        public ShowController(ILogger<ShowController> logger, ShowsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(List<Show>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                if (_context.Shows == null || !_context.Shows.Any())
                    return NotFound("No Show found in the database");
                return Ok(_context.Shows?.ToList());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet]
        [Route("ById")]
        [ProducesResponseType(typeof(Show), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int ID)
        {
            try
            {
                var show = _context.Shows?.Find(ID);
                if (show == null)
                {
                    return NotFound("The requested resource was not found");
                }
                return Ok(show);
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
                var person = _context.Shows?.Find(ID);
                if (person == null)
                {
                    return NotFound($"Show with id {ID} was not found");
                }
                _context.Shows?.Remove(person);
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
        public IActionResult Add(Show showToAdd)
        {
            if (showToAdd.ID != 0)
            {
                return BadRequest("ID was provided but not needed");
            }
            try
            {
                //ShowToAdd.Id = 0;
                _context.Shows?.Add(showToAdd);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok($"Show {showToAdd.ShowsName} added successfully");
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
        public IActionResult Put(Show personToEdit)
        {
            if (personToEdit.ID < 1)
            {
                return BadRequest("Please provide a valid id");
            }
            try
            {
                var show = _context.Shows?.Find(personToEdit.ID);
                if (show == null)
                    return NotFound("The Show was not found");
                show.ShowsName = personToEdit.ShowsName;
                show.Person = personToEdit.Person;
                show.Seasons = personToEdit.Seasons;
                _context.Shows?.Update(show);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok("Show was edited successfully");
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