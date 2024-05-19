using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Core.Models;
using OnionArchitecture.TaskManager.Core.Interfaces;
using OnionArchitecture.TaskManager.Application.DTOs;

namespace OnionArchitecture.TaskManager.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (project != null)
            {
                return new ProjectDTO
                {
                    Id = project.Id,
                    Name = project.Name,
                    CreatedAt = project.CreatedAt,
                    CreatedBy = project.CreatedBy,
                    ModifiedAt = project.ModifiedAt,
                    ModifiedBy = project.ModifiedBy
                };
            }
            return null;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects.Select(project => new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                CreatedAt = project.CreatedAt,
                CreatedBy = project.CreatedBy,
                ModifiedAt = project.ModifiedAt,
                ModifiedBy = project.ModifiedBy
            });
        }

        public async Task AddProjectAsync(ProjectDTO projectDto)
        {
            var project = new Project
            {
                Id = projectDto.Id,
                Name = projectDto.Name,
                CreatedAt = projectDto.CreatedAt,
                CreatedBy = projectDto.CreatedBy,
                ModifiedAt = projectDto.ModifiedAt,
                ModifiedBy = projectDto.ModifiedBy
            };
            await _projectRepository.AddAsync(project).ConfigureAwait(false);
        }

        public async Task UpdateProjectAsync(ProjectDTO projectDto)
        {
            var project = await _projectRepository.GetByIdAsync(projectDto.Id).ConfigureAwait(false);

            if (project == null)
            {
                throw new Exception("Project does not exist");
            }

            if (projectDto.Name != null && project.Name != projectDto.Name) project.Name = projectDto.Name;

            if (projectDto.CreatedAt != DateTime.MinValue && project.CreatedAt != projectDto.CreatedAt) project.CreatedAt = projectDto.CreatedAt;

            if (projectDto.CreatedBy > 0 && project.CreatedBy != projectDto.CreatedBy) project.CreatedBy = projectDto.CreatedBy;

            if (projectDto.ModifiedAt != DateTime.MinValue && project.ModifiedAt != projectDto.ModifiedAt) project.ModifiedAt = projectDto.ModifiedAt;

            if (projectDto.ModifiedBy > 0 && project.ModifiedBy != projectDto.ModifiedBy) project.ModifiedBy = projectDto.ModifiedBy;

            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteAsync(id);
        }
    }
}
