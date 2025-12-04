using NUnit.Framework;

public abstract class TestBase
{
    protected CustomWebApplicationFactory Factory;
    protected HttpClient Client;

    [OneTimeSetUp] 
    public void GlobalSetup()
    {
        Factory = new CustomWebApplicationFactory();
        Client = Factory.CreateClient();
    }

    public async Task CleanDB()
    {
        await Factory.ResetDatabaseAsync(); // Clean DB for every test
    }
}
