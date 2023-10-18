using Newtonsoft.Json;
using RestSharp;
using RestSharpDemo.Models;
using RestSharpFamework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class CreateOperation
    {
        private Helper helper;

        public CreateOperation()
        {
            helper = new Helper();
        }
        public IRestResponse GetUsers()
        {
            var client = helper.SetUrl("api/users");
            var request = helper.CreateGetRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("page", 2);
            var response = helper.GetResponse(client, request);
            return response;
        }

        public IRestResponse CreateNewUser(dynamic payload)
        {
            var client = helper.SetUrl("api/users");
            var jsonString = HandleContent.SerializeJsonString(payload);
            var request= helper.CreatePostRequest(jsonString);

            var response = helper.GetResponse(client, request);
            return response;


        }

        public IRestResponse GetSingleUser(string id)
        {
            var client = helper.SetUrl($"api/users/{id}");
            var request = helper.CreateGetRequest();

            var response = helper.GetResponse(client, request);
            return response;

        }
    }
}
