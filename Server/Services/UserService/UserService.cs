using Dapper;
using Domain.Entities;
using Hepra_testing_Mudblazor.Server.Data;
using Microsoft.Data.SqlClient;

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

                return null;
            }
        }

        public async Task<List<User>> DeleteUserById(int id)
        {
            try
            {
                var user = await GetUserById(id);

                if (user == null)
                {
                    return null;
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

                return null;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var user = await connection.QueryFirstOrDefaultAsync<User>($"select * from Users where Id = {id}");
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var users = await connection.QueryAsync<List<User>>("select * from Users");
            return users;
        }

        public async Task<List<User>> UpdateUser(User user)
        {
            try
            {
                var dbUser = await GetUserById(user.Id);
                if (dbUser == null)
                {
                    return null;
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

                return null;
            }
        }
    }
}
