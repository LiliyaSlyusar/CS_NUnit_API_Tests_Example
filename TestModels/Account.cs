using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_NUnit_API_Tests_Example.TestModels
{
    /// <summary>
    /// Test model that represents the Account entity in the real application.
    /// Will be used to holde test data.
    /// </summary>
    internal class Account
    {
        public string? Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? AccountType { get; set; }
        public string? OwnerId { get; set; }
    }
}
