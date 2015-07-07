namespace WhereIsMyColleague.API.Controllers
{
  using System.Linq;
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
    public IHttpActionResult Get(string location = null, string duration = null, string name = null)
    {
      var userList = _userRepository.GetAll()
        .Where(x => location != null ? x.PartitionKey == location : x.PartitionKey != null)
        .Where(x => duration != null ? x.Duration == duration : x.Duration != null)
        .Where(x => name != null ? x.RowKey == name : x.RowKey != null)
        .Where(x => x.TimeStamp == DateTime.Now.ToShortDateString());

      var users = userList.Select(u => new UserRequest
      {
        Name = u.RowKey,
        Location = (LocationEnum) Enum.Parse(typeof(LocationEnum), u.PartitionKey),
        Duration = (DurationEnum) Enum.Parse(typeof(DurationEnum), u.Duration),
        SecondLocation = u.IsHalfDay ? (LocationEnum)Enum.Parse(typeof(LocationEnum), u.SecondLocation) : (LocationEnum?)null
      });

      return Ok(users);
    }

    [Route("{id}", Name = "GetUserById")]
    public UserRequest GetUser(string id)
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

      var user = new UserDTO()
      {
        RowKey = userRequest.Name,
        PartitionKey = userRequest.Location.ToString(),
        Duration = userRequest.Duration.ToString(),
        SecondLocation = userRequest.SecondLocation.ToString(),
        TimeStamp = userRequest.TimeStamp,
        IsHalfDay = userRequest.IsHalfDay
      };

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