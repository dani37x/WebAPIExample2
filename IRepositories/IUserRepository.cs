using WebAPIExample2.Models;

namespace WebAPIExample2.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int userId);
        public Task AddUser(User userModel);
        public Task UpdateUser(User userModel);
        public Task DeleteUser(int userId);
    }
}
