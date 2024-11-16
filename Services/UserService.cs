using Microsoft.EntityFrameworkCore;
using TaskTrack.DAL;
using TaskTrack.DAL.Entities;
using TaskTrack.Services.Contracts;

namespace TaskTrack.Services
{
    public class UserService : IUserService
    {
        private readonly TaskTrackDbContext _context;

        public UserService()
        {
        }


        public UserService(TaskTrackDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while adding the user to the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the user.", ex);
            }
        }

        public async System.Threading.Tasks.Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    throw new KeyNotFoundException($"User with ID {id} not found.");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while deleting the user from the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while deleting the user.", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while retrieving users from the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving users.", ex);
            }
        }

        public async System.Threading.Tasks.Task UpdateUserAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the user.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the user in the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating the user.", ex);
            }
        }
    }
}
