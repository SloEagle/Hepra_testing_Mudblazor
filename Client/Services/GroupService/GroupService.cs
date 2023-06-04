using System.Net.Http.Json;

namespace Hepra_testing_Mudblazor.Client.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly HttpClient _http;

        public GroupService(HttpClient http)
        {
            _http = http;
        }

        public List<Group> Groups { get; set; } = new List<Group>();
        public Group Group { get; set; } = new Group();

        public async Task AddGroup(Group group)
        {
            var response = await _http.PostAsJsonAsync("api/group", group);
            Groups = response.Content.ReadFromJsonAsync<List<Group>>().Result;
        }

        public async Task DeleteGroup(int id)
        {
            var response = await _http.DeleteAsync($"api/group/{id}");
            Groups = response.Content.ReadFromJsonAsync<List<Group>>().Result;
        }

        public async Task GetGroupById(int id)
        {
            var response = await _http.GetFromJsonAsync<Group>($"api/group/{id}");
            Group = response;
        }

        public async Task GetGroups()
        {
            var response = await _http.GetFromJsonAsync<List<Group>>("api/group");
            Groups = response;
        }

        public async Task UpdateGroup(Group group)
        {
            var response = await _http.PutAsJsonAsync("api/group", group);
            Groups = response.Content.ReadFromJsonAsync<List<Group>>().Result;
        }
    }
}
