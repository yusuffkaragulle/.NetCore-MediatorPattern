using MediatorPattern.Commands;
using MediatorPattern.Data;
using MediatorPattern.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPattern.Handlers.CommandsHandles
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Response<Employee>>
    {
        #region Fields

        private readonly MyDbContext _dbContext;

        #endregion

        #region Ctor

        public CreateEmployeeCommandHandler(MyDbContext dbContext) =>
            _dbContext = dbContext;

        #endregion

        #region Methods

        public async Task<Response<Employee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.Employee == null)
                return Response.Fail<Employee>("Employee is not empty");

            var result = await _dbContext.Employees.AddAsync(request.Employee, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Response.Ok(data: result.Entity, "Success");
        }

        #endregion
    }
}
