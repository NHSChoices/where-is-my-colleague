namespace WhereIsMyColleague.API.Controllers
{
  using Models;
  using Repositories;
  using System;
  using System.Linq;
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
      var userList = _userRepository.GetAll();
      var users = userList.Select(u => new UserRequest
      {
        Name = u.RowKey,
        Location = (LocationEnum)Enum.Parse(typeof(LocationEnum), u.PartitionKey),
        Duration = (DurationEnum)Enum.Parse(typeof(DurationEnum), u.Duration),
        TimeStamp = u.TimeStamp
      });

      return Ok(users);
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

      var user = new UserDTO
      {
        RowKey = userRequest.Name,
        PartitionKey = userRequest.Location.ToString(),
        Duration = userRequest.Duration.ToString(),
        TimeStamp = userRequest.TimeStamp
      };

      _userRepository.Register(user);

      return CreatedAtRoute("GetUserById", new {id = user.RowKey}, user);
    }

    [Route("{id}")]
    [HttpDelete]
    public void Delete(string id)
    {
      _userRepository.Delete(id);
    }
  }
}