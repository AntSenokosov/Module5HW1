﻿using Newtonsoft.Json;

namespace Module5HW1.Models.Response;

public class DelayedResponse
{
    [JsonProperty("page")]
    public int Page { get; set; }
    [JsonProperty("per_page")]
    public int PerPage { get; set; }
    [JsonProperty("total")]
    public int Total { get; set; }
    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }
    [JsonProperty("data")]
    public List<User> Users { get; set; } = new List<User>();
    [JsonProperty("support")]
    public Support Support { get; set; } = default!;
}