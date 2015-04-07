namespace WhereIsMyColleague.API.Repositories
{
  using System.Collections.Generic;
  using Models;

  public interface IUserRepository
  {
    IEnumerable<User> GetAll();
    void Register(User user);
    void Delete(string id);
  }
}