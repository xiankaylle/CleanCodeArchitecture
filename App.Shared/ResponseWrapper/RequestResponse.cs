
using System.Text.Json.Serialization;

namespace App.Shared.ResponseWrapper
{
    public class RequestResponse
    {
        [JsonIgnore]
        public ResponseStatusCode ResponseStatusCode { get; set; } = ResponseStatusCode.Ok;
        [JsonIgnore]
        public bool IsSuccess { get { return ResponseStatusCode == ResponseStatusCode.Ok || ResponseStatusCode == ResponseStatusCode.Created; } }
        public string[] ErrorMessages { get; set; }
    }
}
