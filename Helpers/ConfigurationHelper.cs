using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace C_NUnit_API_Tests_Example.Helpers
{
    public class ConfigurationHelper
    {
        /// <summary>
        ///  Pulls config value with specifed type from the app.config file
        /// </summary>
        /// <param name="name"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name];
            Assert.IsNotNull(value, $"AppSettings with name: {name} not found. Please check the applciation configuration");

            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static string GetConnectionString(string name)
        {
            var value = ConfigurationManager.ConnectionStrings[name];
            Assert.IsNotNull(value, $"ConnectionString with name: {name} not found. Please checke the application configuration");
            return value.ConnectionString;
        }
    }
}