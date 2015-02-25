﻿using System.Linq;
using NUnit.Framework;
using WhereIsMyColleague.MVC.Controllers;
using WhereIsMyColleague.MVC.Models;

namespace WhereIsMyColleague.UnitTests
{
    [TestFixture]
    public class UserControllerTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void controller_should_populate_user_list()
        {
            //Arrange
            var fakeUserRepository = new FakeUserRepository(new string[] { "1", "2", "3", "4", "5" });

            var userController = new UserController(fakeUserRepository);
 
            //Act
            var action = userController.Index();
          
            //Assert
            var usersViewModel = (action.ViewData.Model as UsersViewModel);

            Assert.That(usersViewModel.Users.Count(), Is.EqualTo(5));
        }

        [Test]
        public void controller_should_handle_an_empty_user_list()
        {
            //Arrange
            var fakeUserRepository = new FakeUserRepository(new string[] { });

            var userController = new UserController(fakeUserRepository);
 
            //Act
            var action = userController.Index();
          
            //Assert
            var usersViewModel = (action.ViewData.Model as UsersViewModel);

            Assert.That(usersViewModel.Users.Count(), Is.EqualTo(0));
        }

    }

    public class FakeUserRepository : IUserRepository
    {
        private readonly string[] _userList;

        public FakeUserRepository(string[] userList)
        {
            _userList = userList;
        }

        public string[] GetUsers()
        {
            return _userList;
        }
    }

}
