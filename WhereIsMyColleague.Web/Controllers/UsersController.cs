﻿namespace WhereIsMyColleague.Web.Controllers
{
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
    public ViewResult Status()
    {
      return View(_userRepository.GetAll());
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

      return !ModelState.IsValid ? View("RegistrationForm") : View(_userRepository.Register(user));
    }

    [HttpGet]
    [Route("register")]
    public ActionResult RegistrationForm()
    {
      return View();
    }
  }
}