using RestSharp;
using RestSharpFamework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public static class RestHelper
    {

        private static  RestClient restClient;
        private static  RestRequest request;
        private static RestResponse response;
        private const string baseUrl = "https://reqres.in/";

       
        public static IRestResponse ExecuteRequest(Method method, string path, dynamic body, IDictionary<string, object> parameters, IDictionary<string, string> headers)
        {

            var url = Path.Combine(baseUrl, path);
            restClient = new RestClient(url);

            request = new RestRequest(method);
            //request.AddHeader("Accept", "application/json");

            if (headers != null)
            {
                UpdateHeaders(headers);
            }

            if (parameters != null)
            {
                UpdateParameters(parameters);
            }

            if (body != null)
            {
                AddBody(body);
            }

            return restClient.Execute(request);
        }

        private static void AddBody(dynamic body)
        {
            var payload = HandleContent.SerializeJsonString(body);
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            //throw new NotImplementedException();
        }

        private static IRestRequest UpdateHeaders(IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                var key = header.Key;
                var value = header.Value;
                request.AddHeader(key, value);

            }
            return request;
        }

        private static IRestRequest UpdateParameters(IDictionary<string, object> parameters)
        {
            foreach (var parameter in parameters) 
            {
                var key = parameter.Key; 
                var value = parameter.Value; 
                request.AddParameter(key, value);

            }
            return request ;
        }

        
    }
}
