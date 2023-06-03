using Dapper;
using Domain.Entities;
using Hepra_testing_Mudblazor.Server.Data;
using Microsoft.Data.SqlClient;

namespace Hepra_testing_Mudblazor.Server.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<GroupService> _logger;

        public GroupService(DataContext context, IConfiguration configuration, ILogger<GroupService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<List<Group>> AddGroup(Group group)
        {
            try
            {
                _context.Groups.Add(group);
                await _context.SaveChangesAsync();
                return await GetGroups();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<Group>();
            }
        }

        public async Task<List<Group>> DeleteGroupById(int id)
        {
            try
            {
                var group = await GetGroupById(id);

                if (group == null)
                {
                    return new List<Group>();
                }
                else
                {
                    _context.Groups.Remove(group);
                    await _context.SaveChangesAsync();
                    return await GetGroups();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<Group>();
            }
        }

        public async Task<Group> GetGroupById(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var group = await connection.QueryFirstOrDefaultAsync<Group>($"select * from Groups where Id = {id}");
            return group;
        }

        public async Task<List<Group>> GetGroups()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var groups = await connection.QueryAsync<Group>("select * from Groups");
            return groups.ToList();
        }

        public async Task<List<Group>> UpdateGroup(Group group)
        {
            try
            {
                var dbGroup = await GetGroupById(group.Id);
                if (dbGroup == null)
                {
                    return new List<Group>();
                }
                else
                {
                    dbGroup.Name = group.Name;

                    await _context.SaveChangesAsync();

                    return await GetGroups();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<Group>();
            }
        }
    }
}
