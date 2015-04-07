namespace WhereIsMyColleague.Web.Repositories
{
  using System.Collections.Generic;
  using Models;

  public interface IUserRepository
  {
    IEnumerable<User> GetAll();
    User Register(User user);
  }
}