using MediatorPattern.Models;
using MediatR;

namespace MediatorPattern.Commands
{
    public class CreateEmployeeCommand : IRequest<Response<Employee>>
    {
        public Employee Employee { get; set; }
    }
}