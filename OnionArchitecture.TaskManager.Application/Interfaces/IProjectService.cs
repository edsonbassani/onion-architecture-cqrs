using OnionArchitecture.TaskManager.Application.DTOs;

namespace OnionArchitecture.TaskManager.Application.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> GetProjectByIdAsync(int id);
        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();
        Task AddProjectAsync(ProjectDTO project);
        Task UpdateProjectAsync(ProjectDTO project);
        Task DeleteProjectAsync(int id);
    }
}
