using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestSharp;
using C_NUnit_API_Tests_Example.Helpers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace C_NUnit_API_Tests_Example.CommonApiRequests
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseApiTest
    {
        protected virtual string BaseUrl => ConfigurationHelper.Get<string>("BaseUrl");
        protected virtual string Username => ConfigurationHelper.Get<string>("Username");
        protected virtual string Env => ConfigurationHelper.Get<string>("Environment");

        protected RestClient? Client;
        protected RestRequest? Request;
        protected IRestResponse? Response;


        #region Setup & Teardown
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            try
            {
                DoTestFixtureSetup();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
             
            }
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            try
            {
                DoTestFixtureTearDown();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
            }
        }

        protected virtual void DoTestFixtureSetup()
        {
            Client = new RestClient(BaseUrl);
        }

        protected virtual void DoTestFixtureTearDown()
        {
            // Any global clenaups should go here
        }
        #endregion

        #region TestExecutionLogActionAttribute

        [SetUp]
       public void BeforeTest()
            {
                try
                {
                    var message = TestContext.CurrentContext.Test.Name + ": Test Started";
                    Logger.LogInfo(message);
                }
                catch (Exception ex)
                {
                    if (Debugger.IsAttached) Debugger.Break();
                    Logger.LogError(ex.ToString());
                }
            }
        [TearDown]
        public void AfterTest()
            {
                try
                {
                    var message = TestContext.CurrentContext.Test.Name + ": Test " +
                                  TestContext.CurrentContext.Result.Outcome.Status;

                    if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                    {
                        Logger.LogInfo(message);
                    }
                    else
                    {
                        Logger.LogError(message);
                    }
                }
                catch (Exception ex)
                {
                    if (Debugger.IsAttached) Debugger.Break();
                    Logger.LogError(ex.ToString());
                }
            }
        #endregion
    }

}