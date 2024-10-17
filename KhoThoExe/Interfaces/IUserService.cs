using KhoThoExe.DTOs;

namespace KhoThoExe.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> UpdateUserAsync(int userId, UserDto userDto);
        Task<bool> DeleteUserAsync(int userId);
        Task<string> AuthenticateAsync(LoginDto loginDto);
    }
}
