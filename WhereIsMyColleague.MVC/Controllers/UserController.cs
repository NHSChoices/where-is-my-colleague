using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhereIsMyColleague.MVC.Models;
using WhereIsMyColleague.MVC.Repositories;

namespace WhereIsMyColleague.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController() : this(new UserRepository())
        {
            
        }

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: User
        public ViewResult Index()
        {
            var viewResult = View(new UsersViewModel() { Users = GetUsers()});
            return viewResult;
        }

        private string[] GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}