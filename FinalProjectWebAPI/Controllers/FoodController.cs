using FinalProjectWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {

        private readonly ILogger<FoodController> _logger;
        private readonly FoodContext _context;

        public FoodController(ILogger<FoodController> logger, FoodContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("ById")]
        [ProducesResponseType(typeof(Food), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var todo = _context.Foods?.Find(id);
                if (todo == null)
                {
                    return NotFound("The requested resource was not found");
                }
                return Ok(todo);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(List<Food>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                if (_context.Foods == null || !_context.Foods.Any())
                    return NotFound("No ToDos found in the database");
                return Ok(_context.Foods?.ToList());
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
                var food = _context.Foods?.Find(id);
                if (food == null)
                {
                    return NotFound($"Food with id {id} was not found");
                }

                _context.Foods?.Remove(food);
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
        public IActionResult Add(Food foodToAdd)
        {
            //what if they provide an id?
            if (foodToAdd.Id != 0)
            {
                return BadRequest("Id was provided but not needed");
            }
            //1.) Fix it and don't tell and just do it
            //2.) Tell them to fix it
            try
            {
                //todoToAdd.Id = 0;
                _context.Foods?.Add(foodToAdd);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok($"Todo {foodToAdd.Name} added successfully");
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
        public IActionResult Put(Food foodToEdit)
        {
            if (foodToEdit.Id < 1)
            {
                return BadRequest("Please provide a valid id");
            }

            try
            {
                var food = _context.Foods?.Find(foodToEdit.Id);
                if (food == null)
                    return NotFound("The todo was not found");

                food.Name = foodToEdit.Name;
                food.Group = foodToEdit.Group;
                _context.Foods?.Update(food);
                var result = _context.SaveChanges();
                if (result >= 1)
                {
                    return Ok("Todo edited successfully");
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