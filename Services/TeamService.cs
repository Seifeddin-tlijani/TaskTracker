using Microsoft.EntityFrameworkCore;
using TaskTrack.DAL;
using TaskTrack.DAL.Entities;
using TaskTrack.Services.Contracts;


namespace TaskTrack.Services
{
    public class TeamService : ITeamService
    {
        private readonly TaskTrackDbContext _context;

        public TeamService()
        {
        }


        public TeamService(TaskTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            try
            {
                return await _context.Teams.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while retrieving teams from the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving teams.", ex);
            }
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            try
            {
                var team = await _context.Teams.FindAsync(id);
                if (team == null)
                {
                    throw new KeyNotFoundException($"Team with ID {id} not found.");
                }
                return team;
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while retrieving the team from the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving the team.", ex);
            }
        }

        public async System.Threading.Tasks.Task AddTeamAsync(Team team)
        {
            try
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while adding the team to the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the team.", ex);
            }
        }

        public async System.Threading.Tasks.Task UpdateTeamAsync(Team team)
        {
            try
            {
                _context.Teams.Update(team);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the team.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the team in the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating the team.", ex);
            }
        }

        public async System.Threading.Tasks.Task DeleteTeamAsync(int id)
        {
            try
            {
                var team = await _context.Teams.FindAsync(id);
                if (team == null)
                {
                    throw new KeyNotFoundException($"Team with ID {id} not found.");
                }

                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
            catch (KeyNotFoundException ex)
            {
                throw ex; 
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while deleting the team from the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while deleting the team.", ex);
            }
        }
    }
}
