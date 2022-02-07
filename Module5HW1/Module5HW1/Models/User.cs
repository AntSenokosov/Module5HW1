using Newtonsoft.Json;

namespace Module5HW1.Models;

public class User
{
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; } = default!;
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = default!;
        [JsonProperty("last_name")]
        public string LastName { get; set; } = default!;
        [JsonProperty("avatar")]
        public string Avatar { get; set; } = default!;
}