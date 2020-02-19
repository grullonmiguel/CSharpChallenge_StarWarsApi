using Newtonsoft.Json;

namespace StarWarsApi.Core.Models
{
    public class Starship
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Model { get; set; }

        [JsonProperty]
        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "starship_class")]
        public string StarshipClass { get; set; }
    }
}
