using Newtonsoft.Json;

namespace Module5HW1.Models.Response;

public class PutUpdateResponse
{
    [JsonProperty("name")]
    public string Name { get; set; } = default!;
    [JsonProperty("job")]
    public string Job { get; set; } = default!;
    [JsonProperty("updatedAt")]
    public string UpdatedAt { get; set; } = default!;
}