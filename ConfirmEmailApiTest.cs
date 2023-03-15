using C_NUnit_API_Tests_Example.CommonApiRequests;
using C_NUnit_API_Tests_Example.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C_NUnit_API_Tests_Example
{
    [TestFixture]
    public class ConfirmEmailApiTest : BaseApiTest
    {

        [Test, Order(1)]
        public void GetConfirmEmail()
        {
            Request = new RestRequest("Account/ConfirmEmail", Method.GET);

            Response = Client!.Execute(Request);

            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(Response.ContentType, Does.Contain("text/html;"));
            Assert.That(Response.Content, Does.Contain("id=\"emailInput\""));
            Response.Cookies.ToList().ForEach(cookie => Logger.LogInfo(cookie.Name + " = " + cookie.Value));
        }

        [Test, Order(2)]
        public void GetConfirmEmailBadParams()
        {
            Request = new RestRequest("Account/ConfirmEmail", Method.GET);
            Request.AddParameter("userId", "12344321");
            Request.AddParameter("code", "testCode");

            Response = Client!.Execute(Request);

            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(Response.ContentType, Does.Contain("text/html;"));
            Assert.That(Response.Content, Does.Contain("Internal Server Error"));
        }
    }
}
