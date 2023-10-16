using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;
        private const string baseUrl = "https://reqres.in/";

        public RestClient SetUrl (string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            request = new RestRequest (Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

    }
}
