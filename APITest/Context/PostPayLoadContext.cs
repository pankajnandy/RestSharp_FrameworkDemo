using RestSharpDemo.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Context
{
    public class PostPayLoadContext
    {

        public PostPayLoadContext()
        {
            CreateUser = new CreateUserReq();
        }
        public CreateUserReq CreateUser
        { get; set; }



    }
}
