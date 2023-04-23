using RestSharp;
using static SpecflowGroupExcercise.Final_Api_Automation;

namespace SpecflowGroupExcercise.Drivers
{
    public class ApiHelper
    {
        public async Task SingleApiCall(string endpoint, string user, 
            string pass)
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(endpoint,
                Method.Post);
            request.AddJsonBody(new
            {
                userName = user,
                password = pass
            });
            RestResponse response = await client.ExecuteAsync(request);
        }

        public async Task SingleApiCall(string endpoint, object payload = null)
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(endpoint,
                Method.Post);
            request.AddJsonBody(payload);
            RestResponse response = await client.ExecuteAsync(request);
        }

        public async Task SingleApiCall(string endpoint, PostRequestModelNewUser2 payload = null)
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(endpoint,
                Method.Post);
            request.AddJsonBody(payload);
            RestResponse response = await client.ExecuteAsync(request);
        }
    }
}
