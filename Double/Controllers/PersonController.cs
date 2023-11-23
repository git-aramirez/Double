using Double.Core.IServices;
using Double.Core.Services;
using Double.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Properties.Api.Exceptions;

namespace Double.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController: ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;
        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        /*
            <summary>
            This endpoint will try to create a person
            </summary>
        */
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            try
            {
                var personResult = _personService.Create(person);
                _logger.LogInformation("Request successful!");

                return Ok(personResult == true ? "The person was created successful!" : "");
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong! "+ e.Message);
                throw new InternalServerErrorException("Something went wrong! "+ e.Message);
            }
        }

        /*
           <summary>
           This endpoint will try to obtain all people
           </summary>
       */
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var person = _personService.GetAll();
                _logger.LogInformation("Request successful!");

                return Ok(person);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong! "+ e.Message);
                throw new InternalServerErrorException("Something went wrong! "+ e.Message);
            }
        }

        /*
            <summary>
            This endpoint will try to obtain a person
            </summary>
        */
        [HttpGet("{personId}")]
        public IActionResult Get(Guid personId)
        {
            try
            {
                var person = _personService.Get(personId);
                _logger.LogInformation("Request successful!");

                return Ok(person);
            }
            catch (Exception e)
            {
                _logger.LogError("Something went wrong! "+ e.Message);
                throw new InternalServerErrorException("Something went wrong! "+ e.Message);
            }
        }
    }
}
