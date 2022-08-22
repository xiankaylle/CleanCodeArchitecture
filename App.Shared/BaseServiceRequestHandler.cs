using App.Shared.Contracts;
using App.Shared.ResponseWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared
{
    public abstract class BaseServiceRequestHandler<TRequest, TResponse, TDb> : IServiceRequestHandler<TRequest, TResponse>
        where TRequest : IServiceRequest<TResponse>
        where TDb : IDbContext
    {
        public BaseServiceRequestHandler()
        {

        }
        public async Task<ServiceResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
