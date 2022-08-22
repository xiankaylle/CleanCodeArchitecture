using App.Shared.ResponseWrapper;

namespace App.Shared.ResponseWrapper
{
    public class ValidationResult
    {
        public ValidationResult(ResponseStatusCode responseStatusCode, params string[] errors)
        {
            ResponseStatusCode = responseStatusCode;
            Errors = errors;
        }
        public ResponseStatusCode ResponseStatusCode { get; }
        public string[] Errors { get; }
    }
}
