using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Testing.Api.AcceptanceTests
{
    public static class HttpContentExtensions
    {
        public static async Task<JToken> ReadAsync(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            var value = JToken.Parse(json);

            return value;
        }
    }
}