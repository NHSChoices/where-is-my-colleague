namespace WhereIsMyColleague.IntegrationTests
{
  using Microsoft.Owin.Testing;
  using NUnit.Framework;

  [TestFixture]
  public class StartUpTests
  {
    private TestServer _server;

    [TestFixtureSetUp]
    public void TestFixtureSetUp()
    {
      _server = TestServer.Create<Startup>();
    }

    [TestFixtureTearDown]
    public void TestFixtureTearDown()
    {
      _server.Dispose();
    }

    [Test]
    public void should_see_hello_world()
    {
      var response = _server.HttpClient.GetAsync("/").Result;
      var result = response.Content.ReadAsStringAsync().Result;

      Assert.That(result, Is.EqualTo("Move along, nothing to see here..."));
    }
  }
}