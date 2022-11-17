using FinalProjectWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebAPI.Controllers
{
    public class HobbiesController
    {
        [ApiController]
        [Route("[controller]")]
        public class HobbiesController : ControllerBase
        {

            private readonly ILogger<HobbiesController> _logger;
            private readonly HobbiesContext _context;

            public HobbiesController(ILogger<HobbiesController> logger, HobbiesContext context)
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
                    return Ok(hobbies);
                }
                catch (Exception e)
                {
                    return Problem(e.Message);
                }

            }
        }
    }
}
