using Newtonsoft.Json;

namespace Module5HW1.Models.Response;

public class LoginUnsuccessfulResponse
{
    [JsonProperty("error")]
    public string Error { get; set; } = default!;
}