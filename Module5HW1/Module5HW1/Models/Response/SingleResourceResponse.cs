using Newtonsoft.Json;

namespace Module5HW1.Models.Response;

public class SingleResourceResponse
{
    [JsonProperty("data")]
    public Resource Resource { get; set; } = default!;
    [JsonProperty("support")]
    public Support Support { get; set; } = default!;
}