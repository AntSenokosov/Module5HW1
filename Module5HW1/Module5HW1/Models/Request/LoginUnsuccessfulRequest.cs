using Newtonsoft.Json;

namespace Module5HW1.Models.Request;

public class LoginUnsuccessfulRequest
{
    [JsonProperty("email")]
    public string Email { get; set; } = default!;
}