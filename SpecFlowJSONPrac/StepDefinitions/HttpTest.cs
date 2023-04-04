using Newtonsoft.Json;
using TechTalk.SpecFlow.Infrastructure;
using SpecFlowJSONPrac.Support;
using NUnit.Framework;
namespace SpecFlowJSONPrac.StepDefinitions
{
    [Binding]
    public class HttpTest
    {
        HttpClient _httpClient;
        HttpResponseMessage _response;
        string responseBody;
        private readonly ISpecFlowOutputHelper _outputHelper;
        public HttpTest(ISpecFlowOutputHelper _outputHelper)
        {
            _httpClient = new HttpClient();
            this._outputHelper = _outputHelper;
        }

        [Given(@"the user sends a post request with url ""([^""]*)""")]
        public async Task GivenTheUserSendsAPostRequestWithUrl(string uri)
        {
            PostData postData = new PostData()
            {
                name = "Morpheus",
                job = "Leader"
            };
            string data = JsonConvert.SerializeObject(postData);
            var contentData = new StringContent(data);

            _response = await _httpClient.PostAsync(uri, contentData);
            responseBody = await _response.Content.ReadAsStringAsync();
            _outputHelper.WriteLine("Post response is" + responseBody);
        }

        [Then(@"the user should get a success response")]
        public void ThenTheUserShouldGetASuccessResponse()
        {
            {
                Assert.True(_response.IsSuccessStatusCode);
            }
        }
    }
}
