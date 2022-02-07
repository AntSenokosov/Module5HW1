using Newtonsoft.Json;

namespace Module5HW1.Models.Request;

public class PatchUpdateRequest
{
    [JsonProperty("name")]
    public string Name { get; set; } = default!;
    [JsonProperty("job")]
    public string Job { get; set; } = default!;
}