using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Testing.Api.AcceptanceTests.RespondWithCode.Post
{
    [MetricAction]
    [TestFixture(200)]
    [TestFixture(404)]
    [TestFixture(500)]
    public class WhenCalledWithAValidBody
    {
        private readonly int _statusCode;
        private HttpResponseMessage _response;
        private JToken _body;

        public WhenCalledWithAValidBody(int statusCode)
        {
            _statusCode = statusCode;
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            var requestBody = new {ResponseCode = _statusCode };
            var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            _response = await ApiClientSingleton.Client.PostAsync("/api/respondwithcode", requestContent);
            _body = _response.Content.ReadAsync().Result;
        }

        [Test]
        public void ThenTheResponseStatusCodeIsAsExpected()
        {
            _response.StatusCode.Should().Be(_statusCode);
        }

        [Test]
        public void ThenTheResponseBodyIsAsExpected()
        {
            var expectedResponseContent = JToken.FromObject(new { Name = "Badger" });

            _body.Should().BeEquivalentTo(expectedResponseContent);
        }
    }
}