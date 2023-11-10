using RestSharp;
using RestSharpDemo;
using RestSharpDemo.Models.Request;
using RestSharpDemo.Models.Response;
using RestSharpFamework.Utils;
using SpecFlowProject.Context;
using System;
using System.Net;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace APITest.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions
    {

        private UserContext _userContext;
        private IRestResponse response;
        private HttpStatusCode statuscode;
        private dynamic payload;

        public UsersStepDefinitions(UserContext userContext)
        {
            _userContext = userContext;
        }

        [Given(@"I Input name ""([^""]*)""")]
        public void GivenIInputName(string name)
        {
            _userContext.User.name = name;
        }

        [Given(@"I Input job ""([^""]*)""")]
        public void GivenIInputJob(string job)
        {
            _userContext.User.job = job;
        }

        [When(@"I post request to create user")]
        public void WhenIPostRequestToCreateUser()
        {
            _userContext.Headers.Add("Accept", "application/json");
            response = RestHelper.ExecuteRequest(Method.POST, _userContext.Userpath,_userContext.User, null, _userContext.Headers);
        }

        [Then(@"Validate newUser is created")]
        public void ThenValidateNewUserIsCreated()
        {
            var createuser = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(201, (int)response.StatusCode);
            Assert.AreEqual(_userContext.User.name, createuser.name);
            Assert.AreEqual(_userContext.User.job, createuser.job);
        }


        [Given(@"From a list of valid created Users")]
        public void GivenFromAListOfValidCreatedUsers()
        {
            
        }

        [When(@"I try to get details of Single User ""([^""]*)""")]
        public void WhenITryToGetDetailsOfSingleUser(string id)
        {
            _userContext.Userpath = $"api/users/{id}";
            _userContext.Headers.Add("Accept", "application/json");
            response = RestHelper.ExecuteRequest(Method.GET, _userContext.Userpath,null, null, _userContext.Headers);
        }

        [Then(@"Validate I get a success status Code")]
        public void ThenValidateIGetASuccessStatusCode()
        {
            statuscode = response.StatusCode;
            Assert.AreEqual(200, (int)statuscode);
        }

        [Then(@"Validate the User fields")]
        public void ThenValidateTheUserFields()
        {
            var getSingleUser = HandleContent.GetContent<SingleUser>(response);
            var getUserContent = getSingleUser.data;
            Assert.AreEqual(2, getUserContent.id);
            Assert.AreEqual("janet.weaver@reqres.in", getUserContent.email);
            Assert.AreEqual("Janet", getUserContent.first_name);
        }

        [Given(@"From user Path User id ""([^""]*)""")]
        public void GivenFromUserPathUserId(string updateId)
        {
            _userContext.Userpath = $"api/users/{updateId}";
        }

        [Given(@"I try to update  name ""([^""]*)""")]
        public void GivenITryToUpdateName(string updateName)
        {
            _userContext.User.name = updateName;

        }

        [Given(@"I try to update Job ""([^""]*)""")]
        public void GivenITryToUpdateJob(string updateRole)
        {
            _userContext.User.job = updateRole;
        }

        [When(@"I send Put Request")]
        public void WhenISendPutRequest()
        {
            _userContext.Headers.Add("Accept", "application/json");
            response = RestHelper.ExecuteRequest(Method.PUT, _userContext.Userpath, _userContext.User, null, _userContext.Headers);
        }

        [Then(@"Validate I get a PUT status Code")]
        public void ThenValidateIGetAPUTStatusCode()
        {
            statuscode = response.StatusCode;
            Assert.AreEqual(200, (int)statuscode);
        }

        [Then(@"Validate the Put Response fields")]
        public void ThenValidateThePutResponseFields()
        {
            var updateUserContent = HandleContent.GetContent<UpdateUserRes>(response);
            Assert.AreEqual(_userContext.User.name, updateUserContent.name);
            Assert.AreEqual(_userContext.User.job, updateUserContent.job);
        }

        [Given(@"From user Path to patch User id ""([^""]*)""")]
        public void GivenFromUserPathToPatchUserId(string patchId)
        {
            _userContext.Userpath = $"api/users/{patchId}";
        }

        [Given(@"I try to patch update  name ""([^""]*)""")]
        public void GivenITryToPatchUpdateName(string patchName)
        {
            _userContext.User.name = patchName;
        }

        [Given(@"I try to patch update Job ""([^""]*)""")]
        public void GivenITryToPatchUpdateJob(string patchJob)
        {
            _userContext.User.job = patchJob;
        }

        [When(@"I send Patch Request")]
        public void WhenISendPatchRequest()
        {
            _userContext.Headers.Add("Accept", "application/json");
            response = RestHelper.ExecuteRequest(Method.PATCH, _userContext.Userpath, _userContext.User, null, _userContext.Headers);
        }

        [Then(@"Validate I get a patch status Code")]
        public void ThenValidateIGetAPatchStatusCode()
        {
            statuscode = response.StatusCode;
            Assert.AreEqual(200, (int)statuscode);
        }

        [Then(@"Validate the patch Response fields")]
        public void ThenValidateThePatchResponseFields()
        {
            var patchedUserContent = HandleContent.GetContent<UpdateUserRes>(response);
            Assert.AreEqual(_userContext.User.name, patchedUserContent.name);
            Assert.AreEqual(_userContext.User.job, patchedUserContent.job);
        }



    }
}
