using App.Shared.ResponseWrapper;
using MediatR;

namespace App.Shared.Contracts
{
    /// <summary>
    /// I Service Request Handler Encapsulates IRquestHandler to that the response will be type of ServiceResponse
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface IServiceRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, ServiceResponse<TResponse>> where TRequest : IServiceRequest<TResponse>
    {
    }
}
