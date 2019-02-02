using System.Net.Http;
using System.Net.Http.Headers;

namespace StarWarsApi.Services
{
    /// <summary>
    /// https://www.youtube.com/watch?v=aWePkE2ReGw&t=2605s
    /// How To Call An API in C# - Examples, Best Practices, Memory Management, and Pitfalls
    /// </summary>
    internal static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}