namespace WhereIsMyColleague.Web.Repositories
{
  using Models;
  using System.Collections.Generic;

  public interface IUserRepository
  {
    IEnumerable<User> GetAll(string locationFilter);

    User Register(User user);
  }
}