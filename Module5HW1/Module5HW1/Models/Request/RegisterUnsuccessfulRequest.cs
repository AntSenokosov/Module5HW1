using Newtonsoft.Json;

namespace Module5HW1.Models.Request;

public class RegisterUnsuccessfulRequest
{
    [JsonProperty("email")]
    public string Email { get; set; } = default!;
}