using RestSharpDemo.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Context
{
    public class UserContext
    {
        private const string BASE_URL = "https://reqres.in/";
        private string _userPath = "api/users";
        public UserContext()
        {
            User = new CreateUserReq();
            Parameters = new Dictionary<string, object>();
            Headers = new Dictionary<string, string>();
        }

        public string Userpath
        {
            get { return _userPath; }
            set { _userPath = value; }
        }
        public CreateUserReq User
        { get; set; }

        public  Dictionary<string, object> Parameters { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
