using TaskTrack.DAL.Entities;

namespace TaskTrack.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();    
        System.Threading.Tasks.Task AddUserAsync(User user);
        System.Threading.Tasks.Task UpdateUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(int id);                  
    }
}
