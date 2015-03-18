namespace WhereIsMyColleague.Web.Repositories
{
  using System.Collections.Generic;
  using Models;

  public class UserRepository : IUserRepository
  {
    public IEnumerable<User> GetAll()
    {
      return new List<User>
               {
                 new User
                   {
                     Name = "pinky",
                     Location = LocationEnum.Other
                   },
                 new User
                   {
                     Name = "brain",
                     Location = LocationEnum.Training
                   },
               };
    }

    public User Register(User user)
    {
      return new User
               {
                 Name = "Regi",
                 Location = LocationEnum.BridgeWaterPlace
               };
    }
  }
}