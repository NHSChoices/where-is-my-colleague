namespace WhereIsMyColleague.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Models;

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            var client = new HttpClient {BaseAddress = new Uri("https://where-is-fred.azurewebsites.net/")};

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("users").Result;
            if (response.IsSuccessStatusCode)
            {
                var userList = response.Content.ReadAsAsync<IEnumerable<UserDto>>().Result;
                var users = userList.Select(d => new User
                {
                    Name = d.Name,
                    Location = d.Location,
                    Duration = d.Duration
                });
                return users;
            }
            return null;
        }

        public User Register(User user)
        {
            var userDto = new UserDto
            {
                Name = user.Name,
                Location = user.Location,
                Duration = user.Duration
            };

            var httpClient = new HttpClient {BaseAddress = new Uri("https://where-is-fred.azurewebsites.net/")};

            var response = httpClient.PostAsJsonAsync("users", userDto).Result;
            if (response.IsSuccessStatusCode)
            {
                return user;
            }
            return null;
        }
    }
}