using System.Net.Http.Json;

namespace Hepra_testing_Mudblazor.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public List<User> Users { get; set; } = new List<User>();
        public User User { get; set; } = new User();

        public async Task AddUser(User user)
        {
            var response = await _http.PostAsJsonAsync("api/user", user);
            Users = response.Content.ReadFromJsonAsync<List<User>>().Result;
        }

        public async Task DeleteUserById(int id)
        {
            var response = await _http.DeleteAsync($"api/user/{id}");
            Users = response.Content.ReadFromJsonAsync<List<User>>().Result;
        }

        public async Task GetUserById(int id)
        {
            var response = await _http.GetFromJsonAsync<User>($"api/user/{id}");
            User = response;
        }

        public async Task GetUsers()
        {
            var response = await _http.GetFromJsonAsync<List<User>>("api/user");
            Users = response;
        }

        public async Task UpdateUser(User user)
        {
            var response = await _http.PutAsJsonAsync("api/user", user);
            Users = response.Content.ReadFromJsonAsync<List<User>>().Result;
        }
    }

}
