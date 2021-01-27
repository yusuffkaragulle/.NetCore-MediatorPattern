using System.Collections.Generic;
using MediatorPattern.Models;
using MediatR;

namespace MediatorPattern.Queries
{
    public class GetAllEmployeeQuery : IRequest<Response<IEnumerable<Employee>>> { }
}
