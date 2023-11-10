using RestSharpDemo;
using RestSharpDemo.Models;
using RestSharpDemo.Models.Request;
using RestSharpDemo.Models.Response;
using RestSharpFamework.Utils;
using System.Net;

namespace API_MSTest
{
    [TestClass]
    public class APITest
    {
        HttpStatusCode statuscode;

        [TestMethod] 
        public void GetListUsers()
        {
            var api = new CreateOperation();
            var response = api.GetUsers();
            Users users = HandleContent.GetContent<Users>(response);
            Assert.AreEqual(2, users.page);
            Assert.AreEqual(12, users.total);

            /// Assert Lindsay Ferguson is a user by querying “List Users”. 
            string searchFirstName = "Lindsay";
            string searchLastName = "Ferguson";
            bool searchUser = false;
            for (int usercount = 0; usercount < (users.total)-1; usercount++)
            {
                if (users.data[usercount].first_name == searchFirstName && users.data[usercount].last_name == searchLastName)
                {                    
                    searchUser = true;
                    break;
                } 
            }
            Assert.IsTrue(searchUser);
            
        }

        [TestMethod]
        public void CreateNewUserTest()
        {
            
            var user = new CreateUserReq
            {
                name = "Pankaj",
                job = "Ops"
            };
            var api = new CreateOperation();

            var response = api.CreateNewUser(user);
            var createuser = HandleContent.GetContent<CreateUserRes>(response);

            //Assert.AreEqual("morpheus", response.name);
            Assert.AreEqual(user.name, createuser.name);

        }

        /// <summary>
        /// Create Test Using Test data
        /// </summary>
        [DeploymentItem(@"TestData")]
        [TestMethod]
        public void CreateNewUserFromFile()
        {

            var payload = HandleContent.ParseJson<CreateUserReq>(@"CreateUserReq.json");

            var api = new CreateOperation();
            var response = api.CreateNewUser(payload);
            statuscode = response.StatusCode;
            Assert.AreEqual(201, (int)statuscode);

            var createUserContent = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(payload.job, createUserContent.job);
            Assert.AreEqual(payload.name, createUserContent.name);

        }
    }
}