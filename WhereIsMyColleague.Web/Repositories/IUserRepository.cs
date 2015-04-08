namespace WhereIsMyColleague.Web.Repositories
{
  using Models;
  using System.Collections.Generic;

  public interface IUserRepository
  {
    IEnumerable<User> GetAll();

    User Register(User user);
  }
}