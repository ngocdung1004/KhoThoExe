using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Services
{
    public class UserService : IUserService
    {
        private readonly KhoThoContext _context;

        public UserService(KhoThoContext context)
        {
            _context = context;
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
                PhoneNumber = userDto.PhoneNumber,
                Address = userDto.Address,
                UserType = userDto.UserType,
                ProfilePicture = userDto.ProfilePicture,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            userDto.UserID = user.UserID; // Get the generated UserID
            return userDto;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users.Select(u => new UserDto
            {
                UserID = u.UserID,
                FullName = u.FullName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address,
                UserType = u.UserType,
                ProfilePicture = u.ProfilePicture,
                CreatedAt = u.CreatedAt
            }).ToListAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return new UserDto
            {
                UserID = user.UserID,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                UserType = user.UserType,
                ProfilePicture = user.ProfilePicture,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<UserDto> UpdateUserAsync(int userId, UserDto userDto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            user.FullName = userDto.FullName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Address = userDto.Address;
            user.UserType = userDto.UserType;
            user.ProfilePicture = userDto.ProfilePicture;

            await _context.SaveChangesAsync();
            return userDto;
        }
    }
}
