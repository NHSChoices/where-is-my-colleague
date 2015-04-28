namespace WhereIsMyColleague.Web.Tests.Unit.Controllers
{
  using NUnit.Framework;
  using System.Web.Mvc;
  using Web.Controllers;

  [TestFixture]
  internal class AccountControllerTests
  {
    [Test]
    public void login_link_should_return_view()
    {
      var controller = new AccountController();

      var result = controller.Login("Login") as ViewResult;

      Assert.That(result, Is.Not.Null);
    }
  }
}