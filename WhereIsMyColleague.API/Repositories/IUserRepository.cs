namespace WhereIsMyColleague.API.Repositories
{
  using Models;
  using System.Collections.Generic;

  public interface IUserRepository
  {
    IEnumerable<UserDTO> GetAll();
    void Register(UserDTO user);
    void Delete(string id);
  }
}