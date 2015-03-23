﻿namespace WhereIsMyColleague.Web.Tests.Unit.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;
    using NSubstitute;
    using NUnit.Framework;
    using Web.Controllers;
    using Web.Repositories;

    [TestFixture]
    public class UsersControllerTests
    {
        private readonly UserDto _userBeingRegistered = new UserDto();
        private readonly User _userToRegister = new User();
        private UsersController _controller;
        private IUserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _controller = new UsersController(_userRepository);
        }

        [Test]
        public void status_should_use_users_from_repo_in_model()
        {
            var emptyUsers = new List<User>();
            _userRepository.GetAll().Returns(emptyUsers);

            var result = _controller.Status();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(emptyUsers));
        }

        [Test]
        public void registering_user_should_send_user_to_repository()
        {
            _controller.Register(_userToRegister);

            _userRepository.Received().Register(_userToRegister);
        }

        [Test]
        public void registering_user_should_return_view_registered_user()
        {
            var registeredUser = new User();

            _userRepository.Register(_userToRegister).Returns(registeredUser);

            var result = (ViewResult) _controller.Register(_userToRegister);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(registeredUser));
        }

        [Test]
        public void registrationform_should_return_view()
        {
            var result = _controller.RegistrationForm() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }
}