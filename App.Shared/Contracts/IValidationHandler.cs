

using App.Shared.ResponseWrapper;

namespace App.Shared.Contracts
{
    public interface IValidationHandler
    {
    }
    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResult> Validate(T request);
    }
}
