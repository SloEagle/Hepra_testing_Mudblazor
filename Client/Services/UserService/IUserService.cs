namespace Hepra_testing_Mudblazor.Client.Services.UserService
{
    public interface IUserService
    {
        List<User> Users { get; set; }
        User User { get; set; }
        Task GetUsers();
        Task GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUserById(int id);
    }
}
