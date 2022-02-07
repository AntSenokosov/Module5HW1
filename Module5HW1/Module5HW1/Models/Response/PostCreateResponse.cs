using Newtonsoft.Json;

namespace Module5HW1.Models.Response;

public class PostCreateResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = default!;
    [JsonProperty("name")]
    public string Name { get; set; } = default!;
    [JsonProperty("job")]
    public string Job { get; set; } = default!;
    [JsonProperty("createdAt")]
    public string CreatedAt { get; set; } = default!;
}