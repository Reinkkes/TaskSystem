using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<UserModel> SearchForId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<List<UserModel>> SearchForUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userByID = await SearchForId(id);

            if (userByID == null)
            {
                throw new Exception($"User : {id} was not found in the database");
            }
            _dbContext.Users.Remove(userByID);
            await _dbContext.SaveChangesAsync();
            return true; 
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userByID = await SearchForId(id);

            if(userByID == null)
            {
                throw new Exception($"User : {id} was not found in the database");
            }
            userByID.Name = user.Name;
            userByID.Email = user.Email;

            _dbContext.Users.Update(userByID);
            await _dbContext.SaveChangesAsync();
            return userByID;
        }
    }
}
