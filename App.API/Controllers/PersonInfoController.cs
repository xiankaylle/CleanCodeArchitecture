using App.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(template: nameof(GetListOfPerson), Name = nameof(GetListOfPerson))]
        public async Task<IActionResult> GetListOfPerson()
        {
            var response = await _mediator.Send(new GetPeopleQuery());

            return Ok(response);
        }
        [HttpGet(template: nameof(GetPersonById), Name = nameof(GetPersonById))]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var response = await _mediator.Send(new GetPersonByIdQuery { PersonId = id});

            return Ok(response);
        }
    }
}
