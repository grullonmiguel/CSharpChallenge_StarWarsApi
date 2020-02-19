using Newtonsoft.Json;

namespace StarWarsApi.Core.Models
{
    public class Vehicle
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Model { get; set; }

        [JsonProperty]
        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "vehicle_class")]
        public string VehicleClass { get; set; }
    }
}