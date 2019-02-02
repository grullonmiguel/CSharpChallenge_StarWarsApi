using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsApi.Services
{
    internal class SwapiProcessor
    {
        private People _people;

        public SwapiProcessor()
        {
            ApiHelper.InitializeClient();
        }

        public async Task<People> GetCharacterAsync(int id)
        {
            using (HttpResponseMessage peopleResponse = await ApiHelper.ApiClient.GetAsync($"https://swapi.co/api/people/{id}"))
            {
                if (peopleResponse.IsSuccessStatusCode)
                {
                    _people = await peopleResponse.Content.ReadAsAsync<People>();

                    _people.Id = id;

                    if (_people.Vehicles.Count > 0)
                        await GetVehicleResponseAsync();

                    if (_people.Starships.Count > 0)
                        await GetStarshipResponseAsync();

                    return _people;
                }
                else
                {
                    throw new Exception(peopleResponse.ReasonPhrase);
                }
            }
        }

        private async Task GetVehicleResponseAsync()
        {
            _people.VehicleList.Add(new Vehicle() { Name = "VEHICLES" });

            foreach (var url in _people.Vehicles)
            {
                var vehicleResponse = await ApiHelper.ApiClient.GetAsync(url);
                if (vehicleResponse.IsSuccessStatusCode)
                {
                    var vehicle = await vehicleResponse.Content.ReadAsAsync<Vehicle>();
                    _people.VehicleList.Add(vehicle);
                }
            }
        }

        private async Task GetStarshipResponseAsync()
        {
            _people.StarshipList.Add(new Starship() { Name = "STARSHIPS" });

            foreach (var url in _people.Starships)
            {
                var starshipResponse = await ApiHelper.ApiClient.GetAsync(url);
                if (starshipResponse.IsSuccessStatusCode)
                {
                    var starship = await starshipResponse.Content.ReadAsAsync<Starship>();
                    _people.StarshipList.Add(starship);
                }
            }
        }

    }
}