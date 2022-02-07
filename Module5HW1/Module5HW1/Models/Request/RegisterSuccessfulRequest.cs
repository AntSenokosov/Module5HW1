using Newtonsoft.Json;

namespace Module5HW1.Models.Request;

public class RegisterSuccessfulRequest
{
    [JsonProperty("email")]
    public string Email { get; set; } = default!;

    [JsonProperty("password")]
    public string Password { get; set; } = default!;
}