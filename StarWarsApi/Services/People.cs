using System.Collections.Generic;

namespace StarWarsApi.Services
{
    internal class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birth_Year { get; set; }
        public string Gender { get; set; }
        public string Eye_Color { get; set; }
        public string Hair_Color { get; set; }
        public string Skin_Color { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Starships { get; set; }
        public List<Vehicle> VehicleList { get; set; }
        public List<Starship> StarshipList { get; set; }

        public People()
        {
            VehicleList = new List<Vehicle>();
            StarshipList = new List<Starship>();
        }
    }
}