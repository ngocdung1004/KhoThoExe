using System;
using System.ComponentModel.DataAnnotations;

namespace KhoThoExe.Models
{
    public enum UserType
    {
        Admin,
        Customer,
        Worker
    }

    public class User
    {
        public int UserID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Sử dụng UserType thay vì string
        public UserType UserType { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
