using OnionArchitecture.TaskManager.Application.DTOs;

namespace OnionArchitecture.TaskManager.Application.Interfaces
{
    public interface IProjectTaskService
    {
        Task<ProjectTaskDTO> GetProjectTaskByIdAsync(int id);
        Task<IEnumerable<ProjectTaskDTO>> GetAllProjectTasksAsync(int projectId);
        Task AddProjectTaskAsync(ProjectTaskDTO projectTask);
        Task UpdateProjectTaskAsync(ProjectTaskDTO projectTask);
        Task DeleteProjectTaskAsync(int id);
    }
}
