using Domain.Entities;

namespace Hepra_testing_Mudblazor.Server.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroups();
        Task<Group> GetGroupById(int id);
        Task<List<Group>> AddGroup(Group group);
        Task<List<Group>> UpdateGroup(Group group);
        Task<List<Group>> DeleteGroupById(int id);
    }
}
