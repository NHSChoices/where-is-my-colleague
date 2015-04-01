namespace WhereIsMyColleague.API.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Models;
    using Repositories;

    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private IUserRepository _userRepository;

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
            var users = userList.Select(u => new UserDto()
            {
                Name = u.RowKey,
                Location = (LocationEnum)Enum.Parse(typeof(LocationEnum), u.PartitionKey),
                Duration = (DurationEnum)Enum.Parse(typeof(DurationEnum), u.Duration)
            });

            return Ok(users);
        }

        [Route("{id}", Name = "GetUserById")]
        public UserDto GetUser(int id)
        {
            // implementation needed
            return null;
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Post(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                RowKey = userDto.Name,
                PartitionKey = userDto.Location.ToString(),
                Duration = userDto.Duration.ToString()
            };

            _userRepository.Register(user);

            return CreatedAtRoute("GetUserById", new { id = userDto.Name }, userDto);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(string id)
        {
            _userRepository.Delete(id);
        }
    }
}
