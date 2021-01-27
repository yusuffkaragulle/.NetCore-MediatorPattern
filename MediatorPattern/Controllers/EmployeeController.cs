using MediatorPattern.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatorPattern.Commands;
using MediatorPattern.Queries;

namespace MediatorPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public EmployeeController(IMediator mediator) =>
            _mediator = mediator;

        #endregion

        #region Methods

        [HttpGet]
        public async Task<Response<IEnumerable<Employee>>> GetAllEmployee() =>
            await _mediator.Send(new GetAllEmployeeQuery());

        [HttpPost]
        public async Task<Response<Employee>> CreateEmployee([FromBody] CreateEmployeeCommand command) =>
            await _mediator.Send(command);

        #endregion
    }
}
