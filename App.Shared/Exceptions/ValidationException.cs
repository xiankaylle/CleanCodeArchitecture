using App.Shared.ResponseWrapper;
using App.Shared.Contracts;


namespace App.Shared.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
           : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<ResponseStatusCode, string[]>();
        }

        public ValidationException(IDictionary<ResponseStatusCode, string[]> errors)
            : this()
        { 

            Errors = errors;
        }

        public IDictionary<ResponseStatusCode, string[]> Errors { get; }
    }
}
