namespace WhereIsMyColleague.API.Controllers
{
  using System.Collections.Generic;
  using Models;
  using Repositories;
  using System;
  using System.Web.Http;

  [RoutePrefix("users")]
  public class UsersController : ApiController
  {
    private readonly IUserRepository _userRepository;

    public UsersController()
      : this(new UserRepository())
    {
    }

    public UsersController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [Route]
    [HttpGet]
    public IHttpActionResult Get()
    {
      var userListRequest = _userRepository.GetAll();

      var userList = new List<UserRequest>();
      foreach (var user in userListRequest)
      {
        if (user.Duration == "AllDay")
        {
          ModelState.Remove("SecondLocation");

          userList.Add(new UserRequest
          {
            Name = user.RowKey,
            Location = (LocationEnum) Enum.Parse(typeof (LocationEnum), user.PartitionKey),
            Duration = (DurationEnum) Enum.Parse(typeof (DurationEnum), user.Duration),
            TimeStamp = user.TimeStamp
          });
        }
        else
        {
          userList.Add(new UserRequest
            {
              Name = user.RowKey,
              Location = (LocationEnum) Enum.Parse(typeof (LocationEnum), user.PartitionKey),
              Duration = (DurationEnum)Enum.Parse(typeof(DurationEnum), user.Duration),
              SecondLocation = (LocationEnum)Enum.Parse(typeof(LocationEnum), user.SecondLocation),
              TimeStamp = user.TimeStamp,
              IsHalfDay = true
            });
        }
      }

      return Ok(userList);
    }

    [Route("{id}", Name = "GetUserById")]
    public UserRequest GetUser(int id)
    {
      throw new Exception("Not yet implemented");
    }

    [Route]
    [HttpPost]
    public IHttpActionResult Post(UserRequest userRequest)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var user = new UserDTO();

      if (!userRequest.IsHalfDay)
      {
        user.RowKey = userRequest.Name;
        user.PartitionKey = userRequest.Location.ToString();
        user.Duration = userRequest.Duration.ToString();
        user.TimeStamp = userRequest.TimeStamp;
      }
      else
      {
        user.RowKey = userRequest.Name;
        user.PartitionKey = userRequest.Location.ToString();
        user.Duration = userRequest.Duration.ToString();
        user.SecondLocation = userRequest.SecondLocation.ToString();
        user.TimeStamp = userRequest.TimeStamp;
      }

      _userRepository.Register(user);

      return CreatedAtRoute("GetUserById", new { id = user.RowKey }, user);
    }

    [Route("{id}")]
    [HttpDelete]
    public void Delete(string id)
    {
      _userRepository.Delete(id);
    }
  }
}