﻿namespace WhereIsMyColleague.Web.Controllers
{
    using System.Web.Mvc;
    using Models;
    using Repositories;

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
            if (!ModelState.IsValid)
            {
                return View("RegistrationForm");
            }

            return View(_userRepository.Register(user));
        }

        [HttpGet]
        [Route("register")]
        public ActionResult RegistrationForm()
        {
            return View();
        }
    }
}