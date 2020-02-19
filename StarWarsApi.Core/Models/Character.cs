using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsApi.Core.Models
{
    public class Character
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty(PropertyName = "eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "hair_color")]
        public string HairColor { get; set; }

        [JsonProperty]
        public string Height { get; set; }

        [JsonProperty]
        public string Homeworld { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty]
        public string Mass { get; set; }

        /// <summary>
        /// Gets or sets the films URLs.
        /// </summary>
        [JsonProperty]
        public ICollection<string> Films { get; set; }

        /// <summary>
        /// Gets or sets the species URLs.
        /// </summary>
        [JsonProperty]
        public ICollection<string> Species { get; set; }

        /// <summary>
        /// Gets or sets the star ships URLs.
        /// </summary>
        [JsonProperty]
        public ICollection<string> Starships { get; set; }

        /// <summary>
        /// Gets or sets the vehicles URLs.
        /// </summary>
        [JsonProperty]
        public ICollection<string> Vehicles { get; set; }
    }
}