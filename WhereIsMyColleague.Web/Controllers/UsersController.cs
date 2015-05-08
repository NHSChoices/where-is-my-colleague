using Microsoft.Ajax.Utilities;

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
      var userList = _userRepository.GetAll();
      var viewModel = new UsersViewModel()
      {
        User = userList,
        LocationFilter = new LocationEnum()
      };

      if (!String.IsNullOrWhiteSpace(locationFilter))
      {
        viewModel.LocationFilter = (LocationEnum) Enum.Parse(typeof (LocationEnum), locationFilter);
      }
      else
      {
        viewModel.LocationFilter = 0;
      }
      return View(viewModel);
    }

    [HttpPost]
    [Route("register")]
    public ActionResult Register(User user)
    {
      if (user.Duration != 0)
      {
        user.IsHalfDay = true;
      }

      if (!user.IsHalfDay || user.Duration == null)
      {
        ModelState.Remove("SecondLocation");
      }

      HttpCookie usernameCookie = new HttpCookie("usernameCookie");
      usernameCookie.Values.Add("username", user.Name);
      usernameCookie.Expires = DateTime.Now.AddYears(10);
      if (user.Name != null)
      {
        Response.Cookies.Add(usernameCookie);
      }

      return !ModelState.IsValid ? View("RegistrationForm") : View(_userRepository.Register(user));
    }

    [HttpGet]
    [Route("register")]
    public ActionResult RegistrationForm()
    {
      var model = new User
      {
        Location = LocationEnum.BridgeWaterPlace,
        Duration = DurationEnum.AllDay,
        SecondLocation = LocationEnum.Home
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