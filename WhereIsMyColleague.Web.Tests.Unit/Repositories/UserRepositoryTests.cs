namespace WhereIsMyColleague.Web.Tests.Unit.Repositories
{
  using Models;
  using NUnit.Framework;
  using Web.Repositories;

  [TestFixture]
  public class UserRepositoryTest
  {
    private IUserRepository _repository;

    [SetUp]
    public void SetUp()
    {
      _repository = new UserRepository();
    }

    [Test, Ignore]
    public void should_call_api_for_users()
    {
      var users = _repository.GetAll(null);

      Assert.That(users, Is.Not.Null);
    }

    [Test, Ignore]
    public void should_send_user_to_api_for_regsitration()
    {
      var user = new User();

      //var result = _repository.Register(user);

      //Assert.That(result, Is.True);
    }
  }
}