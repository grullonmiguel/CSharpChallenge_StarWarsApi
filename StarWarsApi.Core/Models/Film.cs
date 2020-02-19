using Newtonsoft.Json;

namespace StarWarsApi.Core.Models
{
    public class Film
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }
    }
}
