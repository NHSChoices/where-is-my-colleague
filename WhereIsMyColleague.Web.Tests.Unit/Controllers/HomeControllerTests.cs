namespace WhereIsMyColleague.Web.Tests.Unit.Controllers
{
    using System.Web.Mvc;
    using NUnit.Framework;
    using Web.Controllers;

    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void should_return_view()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }
}