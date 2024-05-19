using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Core.Models;
using OnionArchitecture.TaskManager.Core.Interfaces;
using OnionArchitecture.TaskManager.Application.DTOs;

namespace OnionArchitecture.TaskManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (user != null)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    FirstName = user.FirstName,
                    Login = user.Login,
                    Token = user.Token,
                    CreatedAt = user.CreatedAt,
                    CreatedBy = user.CreatedBy,
                    ModifiedAt = user.ModifiedAt,
                    ModifiedBy = user.ModifiedBy
                };
            }
            return null;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                FirstName = user.FirstName,
                Login = user.Login,
                Token = user.Token,
                CreatedAt = user.CreatedAt,
                CreatedBy = user.CreatedBy,
                ModifiedAt = user.ModifiedAt,
                ModifiedBy = user.ModifiedBy
            });
        }

        public async Task AddUserAsync(UserDTO userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                FirstName = userDto.FirstName,
                Login = userDto.Login,
                Token = userDto.Token,
                CreatedAt = userDto.CreatedAt,
                CreatedBy = userDto.CreatedBy,
                ModifiedAt = userDto.ModifiedAt,
                ModifiedBy = userDto.ModifiedBy
            };
            await _userRepository.AddAsync(user).ConfigureAwait(false);
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id).ConfigureAwait(false);

            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            if (userDto.Name != null && user.Name != userDto.Name) user.Name = userDto.Name;

            if (userDto.FirstName != null && user.FirstName != userDto.FirstName) user.FirstName = userDto.FirstName;

            if (userDto.Login != null && user.Login != userDto.Login) user.Login = userDto.Login;

            if (userDto.Token != null && user.Token != userDto.Token) user.Token = userDto.Token;

            if (userDto.CreatedAt != DateTime.MinValue && user.CreatedAt != userDto.CreatedAt) user.CreatedAt = userDto.CreatedAt;

            if (userDto.CreatedBy > 0 && user.CreatedBy != userDto.CreatedBy) user.CreatedBy = userDto.CreatedBy;

            if (userDto.ModifiedAt != DateTime.MinValue && user.ModifiedAt != userDto.ModifiedAt) user.ModifiedAt = userDto.ModifiedAt;

            if (userDto.ModifiedBy > 0 && user.ModifiedBy != userDto.ModifiedBy) user.ModifiedBy = userDto.ModifiedBy;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
