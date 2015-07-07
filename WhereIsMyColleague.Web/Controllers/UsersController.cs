using System.Linq;

namespace WhereIsMyColleague.Web.Controllers
{
  using System;
  using System.Web;
  using Models;
  using Repositories;
  using System.Web.Mvc;

  [RoutePrefix("Users")]
  public class UsersController : Controller
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
    public ViewResult Status(string locationFilter)
    {
      switch (locationFilter)
      {
        #region Translates integral value to string
        case "1":
          locationFilter = "AnnualLeave";
          break;
        case "2":
          locationFilter = "BridgeWaterPlace";
          break;
        case "3":
          locationFilter = "Home";
          break;
        case "4":
          locationFilter = "Ill";
          break;
        case "5":
          locationFilter = "Offsite";
          break;
        case "6":
          locationFilter = "Other";
          break;
        case "7":
          locationFilter = "SkiptonHouse";
          break;
        case "8":
          locationFilter = "Training";
          break;
        default:
          locationFilter = null;
          break;
        #endregion
      }

      var userList = _userRepository.GetAll(locationFilter);
      var viewModel = new UsersViewModel()
      {
        User = userList,
        LocationFilter = locationFilter == null ?
        new LocationEnum() : (LocationEnum)Enum.Parse(typeof(LocationEnum), locationFilter)
      };

      return View(viewModel);
    }

    [HttpPost]
    [Route("register")]
    public ActionResult Register(User user)
    {
      if (!user.IsHalfDay || user.Duration == null)
      {
        ModelState.Remove("SecondLocation");
      }

      if (!ModelState.IsValid)
      {
        var state = ModelState.FirstOrDefault(x => x.Key.Equals("Name"));
        if (state.Value.Errors.Any(x => x.ErrorMessage == "You entered your name incorrectly. Please try again"))
        {
          ModelState.Remove("Name");

          user.Name = string.Empty;
          ModelState.AddModelError("Name", "You entered your name incorrectly. Please try again");

          return View("RegistrationForm", user);
        }

        return View("RegistrationForm");
      }

      HttpCookie usernameCookie = new HttpCookie("usernameCookie");
      usernameCookie.Values.Add("username", user.Name);
      usernameCookie.Expires = DateTime.Now.AddYears(10);
      if (user.Name != null)
      {
        Response.Cookies.Add(usernameCookie);
      }

      return View(_userRepository.Register(user));
    }

    [HttpGet]
    [Route("register")]
    public ActionResult RegistrationForm()
    {
      var model = new User
      {
        Location = LocationEnum.BridgeWaterPlace,
        Duration = DurationEnum.AllDay
      };

      if (Request != null)
      {
        HttpCookie usernameCookie = Request.Cookies["usernameCookie"];
        if (usernameCookie != null)
        {
          if (!string.IsNullOrEmpty(usernameCookie.Values["username"]))
          {
            model.Name = usernameCookie.Values["username"];
          }
        }
      }

      return View(model);
    }
  }
}