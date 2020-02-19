using StarWarsApi.Core.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StarWarsApi.Core.Services
{
    public class ApiService
    {
        private readonly HttpClient client;

        public ApiService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Result<T>> GetAsync<T>(string uri)
        {
            using HttpResponseMessage request = await client.GetAsync(uri);
            
            return request.IsSuccessStatusCode ? 
                Result.Ok(await request.Content.ReadAsAsync<T>()) :
                Result.Fail<T>(request.ReasonPhrase);
        }
    }
}