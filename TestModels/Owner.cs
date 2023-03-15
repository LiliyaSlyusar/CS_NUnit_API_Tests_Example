using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace C_NUnit_API_Tests_Example.TestModels
{
    /// <summary>
    /// Test model that represents the Owner entity in the real application.
    /// Will be used to holde test data..
    /// </summary>
    internal class Owner
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}

