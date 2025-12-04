using NUnit.Framework;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;

[TestFixture]
public class Tests : TestBase
{
    [SetUp] // 🔥 runs before every test
    public void Setup()
    {
        await CleanDB(); // Clean DB for every test

        // Seed fresh data
        _db.Users.AddRange(SeedData.Users);
        _db.SaveChanges();
    }


    [Test]
    [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.Cases))]
    public async Task CreateUser_Should_Return_ExpectedStatus(
        string name, string email, int expectedStatus)
    {

        //Act
        // Seed an existing user (for duplicate email test)
        if (email == "existing@example.com")
        {
            await Client.PostAsJsonAsync("/api/users", 
                new { Name = "Existing", Email = "existing@example.com" });
        }

        var request = new { Name = name, Email = email };

        var response = await Client.PostAsJsonAsync("/api/users", request);

        //Assert
        ((int)response.StatusCode).Should().Be(expectedStatus);
    }
}
