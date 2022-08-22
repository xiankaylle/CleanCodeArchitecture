using App.Shared.ResponseWrapper;
using App.Shared.Contracts;
using MediatR;
namespace App.Shared
{
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : class, IRequest<TResponse>
       where TResponse : RequestResponse, new()
    {   
        private readonly IValidationHandler<TRequest> _validationHandler;
     
        public ValidationBehaviour(IValidationHandler<TRequest> validationHandler)
        {
            _validationHandler = validationHandler;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validationHandler == null)
            {
                return await next();
            }
            var result = await _validationHandler.Validate(request);
            if (result != null && (result.ResponseStatusCode != ResponseStatusCode.Ok || result.ResponseStatusCode != ResponseStatusCode.Created))
            {
                
                return new TResponse() { ResponseStatusCode = result.ResponseStatusCode, ErrorMessages = result.Errors };
            }
            return await next();
        }
    }
}
