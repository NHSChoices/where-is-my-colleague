namespace WhereIsMyColleague.API.Repositories
{
  using Models;
  using System.Collections.Generic;

  public interface IUserRepository
  {
    IEnumerable<User> GetAll();

    void Register(User user);

    void Delete(string id);
  }
}