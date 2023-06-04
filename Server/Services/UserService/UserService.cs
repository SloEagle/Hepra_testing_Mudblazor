using Microsoft.EntityFrameworkCore;

namespace Hepra_testing_Mudblazor.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IConfiguration _configuration;

        public UserService(DataContext context, ILogger<UserService> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<List<User>> AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return await GetUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<User>();
            }
        }

        public async Task<List<User>> DeleteUserById(int id)
        {
            try
            {
                var user = await GetUserById(id);

                if (user == null)
                {
                    return new List<User>();
                }
                else
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return await GetUsers();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<User>();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Group)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Group)
                .ToListAsync();
            return users;
        }

        public async Task<List<UserDTO>> GetUsersDTO()
        {
            var users = await GetUsers();
            var usersDTO = users.Adapt<List<UserDTO>>();
            return usersDTO;
        }

        public async Task<List<User>> UpdateUser(User user)
        {
            try
            {
                var dbUser = await GetUserById(user.Id);
                if (dbUser == null)
                {
                    return new List<User>();
                }
                else
                {
                    dbUser.Name = user.Name;
                    dbUser.Email = user.Email;
                    dbUser.PhoneNumber = user.PhoneNumber;
                    dbUser.TaxNumber = user.TaxNumber;
                    dbUser.Group = user.Group;

                    await _context.SaveChangesAsync();

                    return await GetUsers();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<User>();
            }
        }
    }
}
