using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsApi.Core.Models
{
    public class Character
    {
        private readonly string _imagePath = "/StarWarsApi;component/Assets/Characters/";

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

        public string URL { get; set; }

        public string World { get; set; }

        public string ImagePath
        {
            get
            {
                    // Note:
                    // Images are stored in the Assets directory
                    // The image 'Build Action' is set to 'Resource'
                    // The image is renamed to the character name with no spaces
                    // The UI will only display the images that exist

                    // Get the name from selected character and remove the empty space
                    var image = Name.Replace(" ", string.Empty) + ".png";

                    // Set the image using the path and image name
                    return $"{_imagePath}{image}";
            }
        }

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