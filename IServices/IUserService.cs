using WebAPIExample2.Models;

namespace WebAPIExample2.IServices
{
    public interface IUserService
    {
        public Task<User> GetUser(int userId);
        public Task AddUser(User userModel);
        public Task UpdateUser(User userModel);
        public Task DeleteUser(int userId);
    }
}
