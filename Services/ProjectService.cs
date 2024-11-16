using Microsoft.EntityFrameworkCore;
using TaskTrack.DAL;
using TaskTrack.DAL.Entities;
using TaskTrack.Services.Contracts;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskTrack.Services
{
    public class ProjectService : IProjectService
    {
        private readonly TaskTrackDbContext _context;

        public ProjectService()
        {
        }

        public ProjectService(TaskTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            try
            {
                return await _context.Projects
                               .Include(p => p.Tasks)  // Includes the related tasks for each project
                               .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while retrieving projects.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving projects.", ex);
            }
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            try
            {
                var project = await _context.Projects.FindAsync(id);
                if (project == null)
                {
                    throw new KeyNotFoundException($"Project with ID {id} not found.");
                }
                return project;
            }
            catch (KeyNotFoundException ex)
            {
                throw ex; 
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving the project.", ex);
            }
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while adding the project.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the project.", ex);
            }
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            try
            {
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the project.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the project.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating the project.", ex);
            }
        }

        public async Task<Project> DeleteProjectAsync(int id)
        {
            try
            {
                var project = await _context.Projects.FindAsync(id);
                if (project == null)
                {
                    throw new KeyNotFoundException($"Project with ID {id} not found.");
                }

                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (KeyNotFoundException ex)
            {
                throw ex; 
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while deleting the project.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while deleting the project.", ex);
            }
        }
    }
}
