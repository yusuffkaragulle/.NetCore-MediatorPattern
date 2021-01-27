using MediatorPattern.Data;
using MediatorPattern.Models;
using MediatorPattern.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPattern.Handlers.QueryHandles
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, Response<IEnumerable<Employee>>>
    {
        #region Fields

        private readonly MyDbContext _dbContext;

        #endregion

        #region Ctor

        public GetAllEmployeeQueryHandler(MyDbContext dbContext) =>
                    _dbContext = dbContext;

        #endregion

        #region Methods

        public async Task<Response<IEnumerable<Employee>>> Handle(GetAllEmployeeQuery request,
            CancellationToken cancellationToken) =>
            Response.Ok((await _dbContext.Employees.ToListAsync(cancellationToken: cancellationToken)).AsEnumerable(), "Success");

        #endregion
    }
}
