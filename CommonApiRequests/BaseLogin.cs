using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_NUnit_API_Tests_Example.CommonApiRequests
{
    // This class can be used to perform intial login before each test to get JWT token or Cookies (depends on the type of authorization)
    public class BaseLogin : BaseApiTest
    {
        /// <summary>
        /// Password can be set via Environmental Variable or via command line parameter with --params
        /// Example for CLI: nunit3-console.exe C#_NUnit_API_Tests_Example.dll --params="password=12345" 
        /// And then use in test like: string password = TestContext.Parameters["password"];
        /// Example For Envirinmental variable: string passwrod = Environment.GetEnvironmentVariable("PASSWORD");
        /// </summary>
        /// <param name="password"></param>
        public string Login(string password) {
            Request = new RestRequest("Account/Login", Method.POST);

            Request.AddParameter("Username", Username);
            Request.AddParameter("Password", password);
            
            Response = Client?.Execute(Request);
            return Response.Content.ToString();
        }
    }
}