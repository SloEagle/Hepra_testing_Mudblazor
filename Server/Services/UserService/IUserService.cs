using Domain.Entities;

namespace Hepra_testing_Mudblazor.Server.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<List<User>> AddUser(User user);
        Task<List<User>> UpdateUser(User user);
        Task<List<User>> DeleteUserById(int id);
    }
}
