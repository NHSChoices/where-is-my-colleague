namespace WhereIsMyColleague.API.Tests.Integration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Microsoft.Owin.Testing;
    using Models;
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
        public void Test()
        {
            var response = _server.HttpClient.GetAsync("/users").Result;
            var result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

            Assert.NotNull(response.Content);
            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
            Assert.AreEqual(4, result.Count());
        }
    }
}