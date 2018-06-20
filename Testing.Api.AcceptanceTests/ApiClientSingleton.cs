using System;
using System.Net.Http;

namespace Testing.Api.AcceptanceTests
{
    public sealed class ApiClientSingleton
    {
        private static readonly Lazy<ApiClientSingleton> Lazy =
            new Lazy<ApiClientSingleton>(() => new ApiClientSingleton());

        private static ApiClientSingleton Instance => Lazy.Value;

        private readonly HttpClient _client;
        public static HttpClient Client => Instance._client;

        private ApiClientSingleton()
        {
            var host = Environment.GetEnvironmentVariable("ApiHost") ?? "http://localhost:5000";

            _client = new HttpClient
            {
                BaseAddress = new Uri(host)
            };
        }
    }
}