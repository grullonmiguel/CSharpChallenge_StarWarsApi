using Newtonsoft.Json;

namespace StarWarsApi.Core.Models
{
    public class Planet
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Climate { get; set; }

        [JsonProperty]
        public string Population { get; set; }
    }
}
