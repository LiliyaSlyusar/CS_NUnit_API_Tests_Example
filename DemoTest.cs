using C_NUnit_API_Tests_Example.CommonApiRequests;
using C_NUnit_API_Tests_Example.TestModels;
using RestSharp;

namespace C__NUnit_API_Tests_Example;

public class Tests : BaseApiTest
{
    List<Owner>? expectedOwners { get; set; }
    string Token { get; set; }


    [SetUp]
    public void Setup()
    {
        // Cleint Initialized in the BaseApiTest so no need to do it here.
        // Only if you need a new RestSharp client instance we can do it here.
        //var newClient = new RestClient(BaseUrl);

        // Init test data.
        // This can be done either with an additional APi request or via DB query.
        expectedOwners = new List<Owner>
        {
            new Owner
            {
                Id = "1",
                Name = "John Smith",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Main St",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Id = "1",
                        DateCreated = new DateTime(2022, 1, 1),
                        AccountType = "Checking",
                        OwnerId = "1"
                    },
                    new Account
                    {
                        Id = "2",
                        DateCreated = new DateTime(2022, 1, 2),
                        AccountType = "Savings",
                        OwnerId = "1"
                    }
                }
            },
            new Owner
            {
                Id = "2",
                Name = "Jane Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = "456 Elm St",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Id = "3",
                        DateCreated = new DateTime(2022, 1, 3),
                        AccountType = "Checking",
                        OwnerId = "2"
                    }
                }
            },

            new Owner
            {
                Id = "3",
                Name = "Bob Johnson",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = "789 Oak St",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Id = "4",
                        DateCreated = new DateTime(2022, 1, 4),
                        AccountType = "Savings",
                        OwnerId = "3"
                    }
                }
            }
        };

        // Init Base Login:
        //var login = new BaseLogin();
        //Token = login.Login(TestContext.Parameters["password"]);
    }

    [Test]
    public void Test1()
    {
        // Create a new RestSharp request
        var request = new RestRequest("owners", Method.GET);

        // SeT Headers with Authorisation token if needed
        // request.AddHeader("Authorisation", "Bearer"+Token)

        // Set the request headers
        request.AddHeader("accept", "*/*");
        
        // Execute the request and get the response
        var response = Client?.Execute(request);

        // Get the actual owners from the response body
        var actualOwners = SimpleJson.DeserializeObject(response!.Content); //pm.response.json()
        if (actualOwners is List<Owner>)
        {
            // Check that the actual owners contain the expected owners
            Assert.That(actualOwners, Is.EquivalentTo(expectedOwners));
        }
        else
        {
            Assert.Fail($"Received content doesn't have an Owner structure. See status code: {response!.StatusCode}");
        }

        
    }
}