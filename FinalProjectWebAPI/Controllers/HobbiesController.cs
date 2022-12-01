using FinalProjectWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebAPI.Controllers
{
    
        [ApiController]
        [Route("[controller]")]
        public class HobbiesController : ControllerBase
        {

            private readonly ILogger<HobbiesController> _logger;
            private readonly FoodContext _context;

            public HobbiesController(ILogger<HobbiesController> logger, FoodContext context)
            {
                _logger = logger;
                _context = context;
            }

            [HttpGet]
            [Route("ById")]
            [ProducesResponseType(typeof(Hobbies), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
            [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]

            public IActionResult GetById(int id)
            {
                try
                {
                    var hobbies = _context.Hobbies?.Find(id);
                    if (hobbies == null)
                    {
                        return NotFound("The requested resource was not found");
                    }
                    if (id == null || id == 0)
                    {
                        return Ok(_context.Hobbies?.Take(5));
                    }
                    return Ok(hobbies);
                }
                catch (Exception e)
                {
                    return Problem(e.Message);
                }

            }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(List<Hobbies>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                if (_context.Hobbies == null || !_context.Hobbies.Any())
                    return NotFound("No Hobbies found in the database");
                return Ok(_context.Hobbies?.ToList());
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
        public IActionResult Delete(int id)
        {
            try
            {
                var hobby = _context.Hobbies?.Find(id);
                if (hobby == null)
                {
                    return NotFound($"Hobby with id {id} was not found");
                }

                _context.Hobbies?.Remove(hobby);
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
        public IActionResult Add(Hobbies hobbyToAdd)
        {
            if (hobbyToAdd.Id != 0)
            {
                return BadRequest("Id was provided but not needed");
            }
            try
            {
                //HobbyToAdd.Id = 0;
                _context.Hobbies?.Add(hobbyToAdd);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok($"Hobby {hobbyToAdd.Name} added successfully");
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
        public IActionResult Put(Hobbies hobbyToEdit)
        {
            if (hobbyToEdit.Id < 1)
            {
                return BadRequest("Please provide a valid id");
            }

            try
            {
                var hobby = _context.Hobbies?.Find(hobbyToEdit.Id);
                if (hobby == null)
                    return NotFound("The hobby was not found");

                
                hobby.Name = hobbyToEdit.Name;
                hobby.Reason = hobbyToEdit.Reason;
                hobby.Days = hobbyToEdit.Days;
                hobby.Hobby = hobbyToEdit.Hobby;
                _context.Hobbies?.Update(hobby);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok("Hobby edited successfully");
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

