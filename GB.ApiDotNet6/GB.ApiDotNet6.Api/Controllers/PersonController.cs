using GB.ApiDotNet6.Application.DTOs;
using GB.ApiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GB.ApiDotNet6.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);
            if(result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
