namespace WhereIsMyColleague.API.Tests.Integration
{
  using Microsoft.Owin.Testing;
  using Models;
  using NUnit.Framework;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net.Http;

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
    public void request_to_api_should_return_ok_status_code()
    {
      var request = _server.HttpClient.GetAsync("/users");

      var response = request.Result.IsSuccessStatusCode;

      Assert.That(response, Is.True);
    }

    [Test]
    public void get_request_to_user_endpoint_should_have_a_response()
    {
      var response = _server.HttpClient.GetAsync("/users").Result;

      Assert.NotNull(response.Content);
    }

    [Test]
    public void the_response_to_the_user_get_request_should_be_json()
    {
      var response = _server.HttpClient.GetAsync("/users").Result;

      Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
    }

    [Test]
    public void get_request_to_user_endpoint_should_return_four_users()
    {
      var response = _server.HttpClient.GetAsync("/users").Result;
      var result = response.Content.ReadAsAsync<IEnumerable<UserRequest>>().Result;

      Assert.AreEqual(4, result.Count());
    }
  }
}