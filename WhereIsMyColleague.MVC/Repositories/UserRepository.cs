using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhereIsMyColleague.MVC.Controllers;

namespace WhereIsMyColleague.MVC.Repositories
{
    public class UserRepository : IUserRepository
    {

        public string[] GetUsers()
        {
            return new string[] { };
        }
    }
}