using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Core.Models;

namespace OnionArchitecture.TaskManager.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task AddUserAsync(UserDTO user);
        Task UpdateUserAsync(UserDTO user);
        Task DeleteUserAsync(int id);
    }
}
