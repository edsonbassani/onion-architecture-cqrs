using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Core.Interfaces;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Core.Models;

namespace OnionArchitecture.TaskManager.Application.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IRepository<ProjectTask> _projectTaskRepository;

        public ProjectTaskService(IRepository<ProjectTask> projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<ProjectTaskDTO> GetProjectTaskByIdAsync(int id)
        {
            var project = await _projectTaskRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (project != null)
            {
                return new ProjectTaskDTO
                {
                    Id = project.Id,
                    Name = project.Name,
                    Assignment = project.Assignment,
                    CompletionDate = project.CompletionDate,
                    DueDate = project.DueDate,
                    ParentTaskId = project.ParentTaskId,
                    ProjectId = project.ProjectId,
                    StartDate = project.StartDate,
                    CreatedAt = project.CreatedAt,
                    CreatedBy = project.CreatedBy,
                    ModifiedAt = project.ModifiedAt,
                    ModifiedBy = project.ModifiedBy
                };
            }
            return null;
        }

        public async Task<IEnumerable<ProjectTaskDTO>> GetAllProjectTasksAsync(int projectId)
        {
            var projects = (await _projectTaskRepository.GetAllAsync().ConfigureAwait(false)).Where(_ => _.ProjectId == projectId);
            return projects.Select(projectTask => new ProjectTaskDTO
            {
                Id = projectTask.Id,
                Name = projectTask.Name,
                Assignment = projectTask.Assignment,
                CompletionDate = projectTask.CompletionDate,
                DueDate = projectTask.DueDate,
                ParentTaskId = projectTask.ParentTaskId,
                ProjectId = projectTask.ProjectId,
                StartDate = projectTask.StartDate,
                CreatedAt = projectTask.CreatedAt,
                CreatedBy = projectTask.CreatedBy,
                ModifiedAt = projectTask.ModifiedAt,
                ModifiedBy = projectTask.ModifiedBy
            });
        }

        public async Task AddProjectTaskAsync(ProjectTaskDTO projectTaskDto)
        {
            var projectTask = new ProjectTask
            {
                Id = projectTaskDto.Id,
                Name = projectTaskDto.Name,
                Assignment = projectTaskDto.Assignment,
                CompletionDate = projectTaskDto.CompletionDate,
                DueDate = projectTaskDto.DueDate,
                ParentTaskId = projectTaskDto.ParentTaskId,
                ProjectId = projectTaskDto.ProjectId,
                StartDate = projectTaskDto.StartDate,
                CreatedAt = projectTaskDto.CreatedAt,
                CreatedBy = projectTaskDto.CreatedBy,
                ModifiedAt = projectTaskDto.ModifiedAt,
                ModifiedBy = projectTaskDto.ModifiedBy
            };
            await _projectTaskRepository.AddAsync(projectTask).ConfigureAwait(false);
        }

        public async Task UpdateProjectTaskAsync(ProjectTaskDTO projectTaskDto)
        {
            var projectTask = await _projectTaskRepository.GetByIdAsync(projectTaskDto.Id).ConfigureAwait(false);

            if (projectTask == null)
            {
                throw new Exception("Project Task does not exist");
            }

            if (projectTaskDto?.Name != null && projectTask.Name != projectTaskDto.Name) projectTask.Name = projectTaskDto.Name;

            if (projectTaskDto?.Assignment != null && projectTask.Assignment != projectTaskDto.Assignment) projectTask.Assignment = projectTaskDto.Assignment;

            if (projectTaskDto?.CompletionDate != null && projectTask.CompletionDate != projectTaskDto.CompletionDate) projectTask.CompletionDate = projectTaskDto.CompletionDate;

            if (projectTaskDto?.DueDate != null && projectTask.DueDate != projectTaskDto.DueDate) projectTask.DueDate = projectTaskDto.DueDate;

            if (projectTaskDto?.ParentTaskId != null && projectTask.ParentTaskId != projectTaskDto.ParentTaskId) projectTask.ParentTaskId = projectTaskDto.ParentTaskId;

            if (projectTaskDto?.ProjectId != null && projectTask.ProjectId != projectTaskDto.ProjectId) projectTask.ProjectId = projectTaskDto.ProjectId;

            if (projectTaskDto?.StartDate != null && projectTask.StartDate != projectTaskDto.StartDate) projectTask.StartDate = projectTaskDto.StartDate;

            if (projectTaskDto?.CreatedAt != DateTime.MinValue && projectTask.CreatedAt != projectTaskDto.CreatedAt) projectTask.CreatedAt = projectTaskDto.CreatedAt;

            if (projectTaskDto.CreatedBy > 0 && projectTask.CreatedBy != projectTaskDto.CreatedBy) projectTask.CreatedBy = projectTaskDto.CreatedBy;

            if (projectTaskDto.ModifiedAt != DateTime.MinValue && projectTask.ModifiedAt != projectTaskDto.ModifiedAt) projectTask.ModifiedAt = projectTaskDto.ModifiedAt;

            if (projectTaskDto.ModifiedBy > 0 && projectTask.ModifiedBy != projectTaskDto.ModifiedBy) projectTask.ModifiedBy = projectTaskDto.ModifiedBy;

            await _projectTaskRepository.UpdateAsync(projectTask);
        }

        public async Task DeleteProjectTaskAsync(int id)
        {
            await _projectTaskRepository.DeleteAsync(id);
        }
    }
}
