using App.Shared.ResponseWrapper;
using MediatR;

namespace App.Shared.Contracts
{

    /// <summary>
    /// Service Request, Encapsulates IRequest
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IServiceRequest<T> : IRequest<ServiceResponse<T>>
    {
    }
}
