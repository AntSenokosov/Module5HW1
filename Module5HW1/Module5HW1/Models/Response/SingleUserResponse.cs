using Newtonsoft.Json;

namespace Module5HW1.Models.Response;

public class SingleUserResponse
{
    [JsonProperty("data")]
    public User User { get; set; } = default!;
    [JsonProperty("support")]
    public Support Support { get; set; } = default!;
}