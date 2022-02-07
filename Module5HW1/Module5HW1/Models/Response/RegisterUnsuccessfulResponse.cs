using Newtonsoft.Json;

namespace Module5HW1.Models.Response;

public class RegisterUnsuccessfulResponse
{
    [JsonProperty("error")]
    public string Error { get; set; } = default!;
}