namespace Hepra_testing_Mudblazor.Client.Services.GroupService
{
    public interface IGroupService
    {
        public List<Group> Groups { get; set; }
        public Group Group { get; set; }
        Task GetGroups();
        Task GetGroupById(int id);
        Task AddGroup(Group group);
        Task UpdateGroup(Group group);
        Task DeleteGroup(int id);
    }
}
