﻿using System.ComponentModel.DataAnnotations;

namespace KhoThoExe.Models
{
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
        public string UserType { get; set; } = "Customer"; // 'Customer', 'Worker'
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
